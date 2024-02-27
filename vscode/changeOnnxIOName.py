import onnx

model = onnx.load(R"R:\squeezenet.onnx")

inputOrgName = model.graph.input[0].name
inputNewName = "inputImage"
model.graph.input[0].name=inputNewName

outputOrgName = model.graph.output[0].name
outputNewName = "outputArray"
model.graph.output[0].name=outputNewName

for node in model.graph.node:
    for i, name in enumerate(node.input):
        if name == inputOrgName:
            node.input[i] = inputNewName

    for i, name in enumerate(node.output):
        if name == outputOrgName:
            node.output[i] = outputNewName

onnx.save(model, R"R:\new_model.onnx")        