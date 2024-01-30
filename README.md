To establish remote connection between more than one nodes on MySQL Server
Devices: A & B
Steps:
1. MySQL installation on both, A & B.
2. On A, open command prompt (CMD) and run the command "ipconfig" to get LAN Adapter IP Address
3. On A, open a CLI (here, cmd) and run the following three commands:
   CREATE USER 'username'@'lan_ip' IDENTIFIED BY 'password';   #replace username, lan_ip, and password according to you
   GRANT ALL PRIVILEGES ON *.* TO 'username'@lan_ip WITH GRANT OPTION;
   FLUSH PRIVILEGES;
   At this moment, A is now a server
4. On B, perform the following opeartions:
   open MySQL Workbench
   Create a new connection by clicking on '+' icon
   Enter a connection name
   In Hostname input field, enter A's IP address
   In Username input field, enter the username created in step 3
   For password, click on Store in Vault and type in the password used in step 3
   Click on test connection button, you will be alerted with a dialog box by the status of connection establishment
   Click OK button
   By now, a new connection will be created on dashbaord
5. Click on the connection to open.
6. Perform the followinf operations on both, A and B:
   Database > Connect to Database > Enter the IP address, username, and password as used in step 3 for both devices
   This will connect the database on both devices
7. Double-click on the schema
8. Create a new table in one of the devices, insert values and run the select query.
9. For the other device, run the select query to see if changes are reflected.
10. If the changes are reflected, connection and database are established and connected securely.

Note: I didn't need to add 'bind - address = lan_ip' in my.ini (in Windows) file. Nor i turned off the firewall for the port 3306 of MySQL to establish connection. 
