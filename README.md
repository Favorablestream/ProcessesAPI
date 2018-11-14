# Processes API

Simple demo of an ASP.Net Core REST API that returns info about the processes running on the server.

## Setup
1. Get the code and build it
2. Generate an HTTPS cert
3. Install nginx and use the provided config (Config/nginx.conf)
4. Setup the HTTP certificate info in nginx.conf and the CERT_PATH and CERT_PAASSWORD constants in Program.cs
4. Start nginx and start the application. Feel free to use the systemd unit file (Config/ProcessesAPI.service)
5. Enjoy!

## Usage
The API should be listening at https://YOURSERVER/api/processes. nginx will proxy the requests to Kestrel.

Available methods:

+ GET api/processes
+ GET api/processes?name=chrome
+ GET api/processes/{PID}
+ DELETE api/processes/{PID}
