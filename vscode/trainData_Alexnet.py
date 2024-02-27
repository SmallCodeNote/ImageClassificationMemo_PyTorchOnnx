import torch
import torchvision
import torchvision.transforms as transforms
import torchvision.models as models
import torch.nn as nn
import torch.optim as optim

def main():
    for i, data in enumerate(trainloader, 0):
        # get the inputs; data is a list of [inputs, labels]
        inputs, labels = data

        # zero the parameter gradients
        optimizer.zero_grad()

        # forward + backward + optimize
        outputs = model(inputs)
        loss = criterion(outputs, labels)
        loss.backward()
        optimizer.step()

        # print statistics
        #running_loss += loss.item()
        #if i % 2000 == 1999:    # print every 2000 mini-batches
        #    print('[%d, %5d] loss: %.3f' % (epoch + 1, i + 1, running_loss / 2000))
        #    running_loss = 0.0


# Load the training and test datasets
transform = transforms.Compose([transforms.Resize(256), transforms.CenterCrop(224), transforms.ToTensor()])
trainset = torchvision.datasets.CIFAR10(root=R"R:\train", train=True, download=True, transform=transform)
trainloader = torch.utils.data.DataLoader(trainset, batch_size=4, shuffle=True, num_workers=2)
testset = torchvision.datasets.CIFAR10(root=R"R:\test", train=False, download=True, transform=transform)
testloader = torch.utils.data.DataLoader(testset, batch_size=4, shuffle=False, num_workers=2)

# Load the pretrained AlexNet model
model = models.alexnet(pretrained=True)

# Replace the last fully connected layer to match the number of classes in the CIFAR-10 dataset
model.classifier[6] = nn.Linear(4096, 10)

# Define the loss function and optimizer
criterion = nn.CrossEntropyLoss()
optimizer = optim.SGD(model.parameters(), lr=0.001, momentum=0.9)

# Train the model
for epoch in range(2):  # loop over the dataset multiple times
    running_loss = 0.0
    if __name__ == '__main__':
        main()

print('Finished Training')

# Save the trained model as an ONNX file
dummy_input = torch.randn(1, 3, 224, 224)
torch.onnx.export(model, dummy_input, R"R:\alexnet.onnx")
