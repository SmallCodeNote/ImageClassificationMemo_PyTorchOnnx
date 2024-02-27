import torch
import torch.nn as nn
import torch.optim as optim
from torchvision import datasets, transforms, models

# Define the device
device = torch.device("cuda" if torch.cuda.is_available() else "cpu")

# Define the transformations for the training and validation datasets
transform = transforms.Compose([
    transforms.Resize(256),
    transforms.CenterCrop(224),
    transforms.ToTensor(),
    transforms.Normalize(mean=[0.485, 0.456, 0.406], std=[0.229, 0.224, 0.225]),
])

# Load the training and validation datasets
train_dataset = datasets.ImageFolder(R"R:\train", transform=transform)
val_dataset = datasets.ImageFolder(R"R:\test", transform=transform)

# Create the dataloaders
train_dataloader = torch.utils.data.DataLoader(train_dataset, batch_size=64, shuffle=True)
val_dataloader = torch.utils.data.DataLoader(val_dataset, batch_size=64, shuffle=True)

# Load the pre-trained ResNet model
model = models.resnet50(pretrained=False)
modelname ="resnet50"
#model = models.alexnet()

# Freeze the parameters of the model
for param in model.parameters():
    param.requires_grad = False

# Replace the last fully connected layer of the model
model.fc = nn.Linear(model.fc.in_features, 1000)


# Move the model to the device
model = model.to(device)

# Define the loss function and the optimizer
criterion = nn.CrossEntropyLoss()

optimizer = optim.SGD(model.fc.parameters(), lr=0.001, momentum=0.9)
#optimizer = optim.SGD(model.parameters(), lr=0.001, momentum=0.9)

# Train the model
for epoch in range(10):  # loop over the dataset multiple times
    running_loss = 0.0
    for inputs, labels in train_dataloader:
        # Move the inputs and labels to the device
        inputs = inputs.to(device)
        labels = labels.to(device)

        # Zero the parameter gradients
        optimizer.zero_grad()

        # Forward pass
        outputs = model(inputs)
        loss = criterion(outputs, labels)

        # Backward pass and optimization
        loss.backward()
        optimizer.step()

        # Print statistics
        running_loss += loss.item()
    print(f"Epoch {epoch + 1}, Loss: {running_loss / len(train_dataloader)}")

print('Finished Training')

# Export the trained model to ONNX
dummy_input = torch.randn(1, 3, 224, 224, device=device)

torch.onnx.export(model, dummy_input, "R:\\" + modelname +".onnx")

print("The trained model is successfully exported to resnet50.onnx")
