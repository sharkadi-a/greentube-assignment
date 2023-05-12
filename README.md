# Greentube Test Assignment

The task was to implement a new .Net Core web service that allows players to log in in case they’ve forgotten their current password simply by knowing the email address they used at registration (which is unique for each player).

## Security considerations

* One potential vulnerability is unauthorized access to an email address, which could allow attackers to reset another person's password.
* Additional authentication measures may be necessary to verify the person requesting the password reset is the actual account owner.
* A limit on password reset attempts within a certain time period could help prevent brute force attacks.
* Denial of service attacks could occur, overwhelming the server with requests. Rate limiting or IP blocking measures could be implemented to prevent this.
* Passwords must be securely stored and transmitted using strong encryption methods to prevent unauthorized access.