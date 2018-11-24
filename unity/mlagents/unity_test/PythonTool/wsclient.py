import asyncio
import websockets

# WSSERVER = 'ws://demos.kaazing.com/echo'
WSSERVER = 'ws://localhost:8765'

async def hello():
    async with websockets.connect(WSSERVER) as websocket:
        name = input("What's your name? ")

        await websocket.send(name)
        print(f"> {name}")

        greeting = await websocket.recv()
        print(f"< {greeting}")

asyncio.get_event_loop().run_until_complete(hello())
