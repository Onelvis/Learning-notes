# EC2, Elastic Compute Cloud

## Pay options
---
- **On demand**: Paid at a fixed rate by the hour/second
- **Reserved**: Provides a capacity reservation, and offer a significcant discount on the hourly charge for an instance
- **Spot**: Enables you tou **bid** whatever price you want for instance capacity.
- **Dedicated Hosts**: Physical EC2 server dedicated for you use.


# Critical terms


## Security Group
---
Is a set of firewall rules that control the traffic of your instance



## Key par
---
Consist of a public key that AWS stores, and a private key that you store. Togheter allow you to connect to your instance securely. You can share the public key, but `NEVER SHARE THE PRIVATE ONE`



# How to's

## Connect to a EC2 by terminal (Linux/Mac)
---
- Add your compure as a known host and connect to the instance
  - Go where you have the private key
  - Change the permissions on the file
        >`chmod 400 MyNewKeyPair.pm`
  - Connect to the instance
    >`ssh ec2-user@35.153.184.58 -i MyNewKeyPar.pem`
- Elevate permissions to root
    > `sudo su`


## Convert the instance into a Web server 
---
- Update the instance
    >`yum update -y`
- Install Apache
    > `yum install httpd -y`
- Start service
    - `service httpd start`
- Configure Apache to initialize automaticly when turning on the instance
    > `checkconfig httpd on`
- Check if running
    > `service httpd status`