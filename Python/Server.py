import time
import zmq

from Audio import AudioClass

class Connection:

    string_message = ""

    @staticmethod
    def server():
        context = zmq.Context()
        socket = context.socket(zmq.REP)
        socket.bind("tcp://*:5555")

        audio = AudioClass

        messages = []
    
        while True:
            #  Wait for next request from client
            message = socket.recv()
            print("Received request: %s" % message)
            Connection.string_message = message.decode("utf-8")

            freq,dur,play = Connection.string_message.split(",")

            audio.playback(int(freq), int(dur), int(play))

            

            messageToUnity = Connection.string_message
            messageToUnityEncoded = messageToUnity.encode()

            #  In the real world usage, you just need to replace time.sleep() with
            #  whatever work you want python to do.-
            #time.sleep(1)
            messages.append(message)

            #  Send reply back to client
            #  In the real world usage, after you finish your work, send your output here
            socket.send(messageToUnityEncoded)


# Instantiate Connection class and call server-function.
server = Connection()
server.server()