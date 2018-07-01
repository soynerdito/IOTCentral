# IotCentral Overview
    To provide an easy open source full free platform for controlling diy projects. Focus on prototyping and makers. Source code should always be fully free and available.

# Main User Story
<p> A person has a microcontroller with a relay and want to control this device from the internet.
    This person will register with this application. Provision an organization space. In this organization the device will be registered to. An unique identifier should be provider. On the person in the organization will have communication with the device. In case the creator of the organization needs to provide access to a different person can invite others to participate and provide access via device or organization level to this other person.
    Once this microcontroller and relay are registered with the service. This person should download some firmware to the microcontroller and set its registration key. 
    Internet access should be provided to the device.
    From within this application the user should be able to create some kind of user inteface that allows messaging to the device. Sending and receiving messages to the device as well as execute some sort of action.
    (NOte) Actions and functionality are not defined. Development of the application is in process and will determine the funcionlity.</p>

# What is a device?
<p>A device is something that can comunicate with the service. Via any of the protocols provided. Depending on the communicaton method device functionality can vary.
    A device can be use for input or output or both, depending on the use case.</p>
## There are different types of devices
### Input_Device
    Receives a messages and do an action with it.
    Message:
        A message can be from a simple On/Off (1,0)
    Action:
        An Action can be forward the message to another device
### Output_Device
    An output device is a device that can receive messages.

## Device examples
<p>    A switch is an example of an outpu device that produces messages of ON, OFF or PUSH but cannot receive a message from the system.
    However a switch with a LED that turns on/off if the action was taken will be an Input and an Output Device at the same time.
    A light bulp can be an OutputDevice that receives data a message from the server saying it should be ON or OFF. A light bulp that responds to the server with the status would be a device that can do Output and Input at the same device.</p>
