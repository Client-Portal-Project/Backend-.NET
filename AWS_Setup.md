## To install Docker on an Amazon EC2 instance

[Click Here for Source Docs](https://docs.aws.amazon.com/AmazonECS/latest/developerguide/docker-basics.html)

1. Launch an instance with the Amazon Linux 2 or Amazon Linux AMI. For more information, see Launching an instance in the Amazon EC2 User Guide for Linux Instances.

2. Connect to your instance. For more information, see Connect to your Linux instance in the Amazon EC2 User Guide for Linux Instances.

3. Update the installed packages and package cache on your instance.

   ```bash
   sudo yum update -y
   ```

4. Install the most recent Docker Engine package.

   - Amazon Linux 2

     ```bash
     sudo amazon-linux-extras install docker
     ```

   - Amazon Linux.

     ```bash
     sudo yum install docker
     ```

5. Start the Docker service.

   ```bash
   sudo service docker start
   ```

6. Add the ec2-user to the docker group so you can execute Docker commands without using sudo.

   ```bash
   sudo usermod -a -G docker ec2-user
   ```

7. Log out and log back in again to pick up the new docker group permissions. You can accomplish this by closing your current SSH terminal window and reconnecting to your instance in a new one. Your new SSH session will have the appropriate docker group permissions.

8. Verify that the ec2-user can run Docker commands without sudo.

   ```bash
   docker info
   ```

### Note 1.1

- In some cases, you may need to reboot your instance to provide permissions for the ec2-user to access the Docker daemon. Try rebooting your instance if you see the following error:

  ```bash
  # "Cannot connect to the Docker daemon. Is the docker daemon running on this host?"
  ```

## Adding your docker image and running it

1. Within the same terminal run the below code to pull the docker image into the EC2

```bash
docker pull mat2718/rest
```

2. Run the newly built image. The -p 80:80 option maps the exposed port 80 on the container to port 80 on the host system. For more information about docker run, go to the Docker run reference.

```bash
docker run -t -i -p 80:80 mat2718/rest
```

### Note 1.2

- Output from the Apache web server is displayed in the terminal window. You can ignore the "Could not reliably determine the server's fully qualified domain name" message.

3. Open a browser and point to the server that is running Docker and hosting your container.

   - If you are using an EC2 instance, this is the Public DNS value for the server, which is the same address you use to connect to the instance with SSH. Do `NOT` use `http://` or `https://` in front of the public DNS value
   - Make sure that the security group for your instance allows inbound traffic on port 80.

4. Stop the Docker container by typing Ctrl + c.
