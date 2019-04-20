Install-Package AWSSDK.SimpleNotificationService -Version 3.3.100.7



1. services => IAM => users => Add user
2. type username
3. choose both Access type  i.e Programmatic access and AWS Management Console access
4. give custom password
5. uncheck => Require password reset
6 Next
7. Attach existing policies directly
8 filter => AmazonSNSFullAccess
9. Next
10 next
11. create user


save 2 imp things

1. Access key ID
2. Secret access key
3. close





Ref:

https://docs.aws.amazon.com/sns/latest/dg/sns-getting-started.html