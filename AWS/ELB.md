# ELB, Elastic Load Balancer

# Types

* **Application Load balancer**: Works on the 7th layer of the OSI model (Application layer)
  * You can create advanced request routing, sending specified request to specific web servers.
* **Network Load Balancer**: Works on the 4th layer of the OSI Model (Transport layer). Used for performance.
  * Are best suited for load balancing of TCP traffic where extreme performance is required.
* **Classic Load Balancer**: Kind of legacy load balancer type.
  * You can load balance HTTP/HTTPS and user Layer 7 specific features, such as X-Forwarded and sticky sessions.
  * You can also use strict Layer 4 load balancing for applications that rely purely on the TCP protocol.

# Load Balancer Errors
* If the application stops responding, the ***Classic*** Load balancer responds with a `504` error. The 504 means the gateway has timed out.



# Critical terms

## X-Forwareded-For Header
This header has the **public ip** (IPv4) of the user that made the request to the Load balancer.

User (124.12.3.231) ---> Load Balancer (10.0.023) ---> Application (Recieves 10.0.0.23, but can lool up for the public ip from the `X-Forwarded-For`)