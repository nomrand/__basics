import http.server
import socketserver
import re

PORT = 8000
OUT_TEXT_PATH = 'result.txt'
OUT_IMAGE_PATH = 'result.png'


def postHappen(body):
    # MUST set encoding = utf-8
    with open(OUT_TEXT_PATH, mode='w', encoding='utf-8') as f:
        f.write(str(body))

def putHappen(body):
    with open(OUT_IMAGE_PATH, mode='wb') as f:
        f.write(body)

class CustomHTTPRequestHandler(http.server.BaseHTTPRequestHandler):

    def do_POST(self):
        content_len = int(self.headers.get('content-length'))
        post_body = self.rfile.read(content_len).decode('UTF-8')
        
        # replace by regex
        text = post_body;
        text = re.sub(r'^.*text=', "", text, flags=(re.MULTILINE | re.DOTALL));
        text = re.sub(r'\n.*$', "", text, flags=(re.MULTILINE | re.DOTALL));

        postHappen(text)

        print('DO POST')
        print(text)
        
        self.send_response(200)
        self.end_headers()
        

    def do_PUT(self):
        content_len = int(self.headers.get('content-length'))
        put_body = self.rfile.read(content_len)
        
        putHappen(put_body)

        print('DO PUT')
        print(put_body[:10])
        print('...print first 10 bytes')
        
        self.send_response(200)
        self.end_headers()


Handler = CustomHTTPRequestHandler

with socketserver.TCPServer(("", PORT), Handler) as httpd:
    print("serving at port", PORT)
    httpd.serve_forever()
