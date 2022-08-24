"""Getting IMU Quaternions

"""
import traceback
import serial_operations as serial_op
from colors import *
import UdpComms as U
import time

# Create UDP socket to use for sending (and receiving)
sock = U.UdpComms(udpIP="127.0.0.1", portTX=8000, portRX=8001, enableRX=True, suppressWarnings=True)

i = 0

# Set parameters that will be configured
imu_configuration = {
    "disableCompass": True,
    "disableGyro": False,
    "disableAccelerometer": False,
    "gyroAutoCalib": True,
    "filterMode": 1,
    "tareSensor": True,
    "logical_ids": [2, 4, 8],
    "streaming_commands": [0, 255, 255, 255, 255, 255, 255, 255]
}
serial_port = serial_op.initialize_imu(imu_configuration)

while True:
    try:
        print('running...')
        bytes_to_read = serial_port.inWaiting()
        
        # NUMERO DO ALEM VAMOS DESCOBRIR PQ - Não tem justificativa ainda.
        if  0 < bytes_to_read > 80:
            print("bytes > 0")
            data = serial_port.read(bytes_to_read)
            if data[0] != 0:
                continue

            if data[1] == 2:
                extracted_data = serial_op.extract_quaternions(data)
                quaternions = extracted_data['quaternions']
#               sock.SendData('Sent from Python: ' + "IMU4 : " + quaternions) # Send this string to other application
#               sock.SendData( 4 + ',' + quaternions)
#                data = sock.ReadReceivedData()  # read data

                print("IMU2: ", quaternions)
#                sock.SendData(str(2) + ',' + str(quaternions))

            if data[1] == 4:
                extracted_data = serial_op.extract_quaternions(data)
                quaternions = extracted_data['quaternions']
#               sock.SendData('Sent from Python: ' + "IMU4 : " + quaternions) # Send this string to other application
#               sock.SendData( 4 + ',' + quaternions)
                data = sock.ReadReceivedData() # read data
                
                print("IMU4: ", quaternions)
            
            if data[1] == 8:
                extracted_data = serial_op.extract_quaternions(data)
                quaternions = extracted_data['quaternions']
#               sock.SendData('Sent from Python: ' + "IMU8 : " + quaternions) # Send this string to other application
#               data = sock.ReadReceivedData() # read data
                
                print("IMU8: ", quaternions)
                sock.SendData( str(8) + ':' + str(quaternions))

    except KeyboardInterrupt:
        print(GREEN, "Keyboard excpetion occured.", RESET)
        serial_port = serial_op.stop_streaming(serial_port, 
                                               imu_configuration['logical_ids'])
        break
    except Exception:
        print(RED, "Unexpected exception occured.", RESET)
        print(traceback.format_exc())
        print(GREEN, "Stop streaming.", RESET)
        serial_port = serial_op.stop_streaming(serial_port, 
                                               imu_configuration['logical_ids'])
        break