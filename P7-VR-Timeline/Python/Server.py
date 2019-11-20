import time
import zmq
import timeit
from threading import Thread
from Audio import AudioClass

class Connection:

    string_message1 = ""
    string_message2 = ""

    
    def server(self):
        context = zmq.Context()
        socket = context.socket(zmq.REP)
        socket.bind("tcp://*:5555")

        audio = AudioClass

        # messages = []
    
        while True:

            #  Wait for next request from client
            message = socket.recv()
            # print("Received request: %s" % message + str(audio.isPlaying))
            Connection.string_message1 = message.decode("utf-8")

            freq,dur,play = Connection.string_message1.split(",")

            print(freq)

            if(float(play) == 1 and audio.isPlaying == False):
                audio.playback(float(freq), float(dur)*2)


            # messageToUnity = Connection.string_message
            # stringToSend = "test"
            # stringToUnity = stringToSend.encode()

            #  In the real world usage, you just need to replace time.sleep() with
            #  whatever work you want python to do.-
            #time.sleep(1)
            # messages.append(message)

            #  Send reply back to client
            #  In the real world usage, after you finish your work, send your output here
            socket.send(b'stringToSend')


    def server2(self):
        context = zmq.Context()
        socket2 = context.socket(zmq.REP)
        socket2.bind("tcp://*:5550")

        audio = AudioClass

        # messages = []
    
        while True:

            #  Wait for next request from client
            message = socket2.recv()
            # print("Received request: %s" % message + str(audio.isPlaying))
            Connection.string_message2 = message.decode("utf-8")

            freq,dur,play = Connection.string_message2.split(",")

            print(freq)

            if(float(play) == 1 and audio.isPlaying == False):
                audio.playback(float(freq), float(dur)*2)


            # messageToUnity = Connection.string_message
            # stringToSend = "test"
            # stringToUnity = stringToSend.encode()

            #  In the real world usage, you just need to replace time.sleep() with
            #  whatever work you want python to do.-
            #time.sleep(1)
            # messages.append(message)

            #  Send reply back to client
            #  In the real world usage, after you finish your work, send your output here
            socket2.send(b'stringToSend')



def main():

    # Instantiate Connection class and call server-function.
    connection = Connection()
    thread1 = Thread(target = connection.server)
    thread2 = Thread(target = connection.server2)
    thread1.start()
    thread2.start()

if __name__ == "__main__":
    main()