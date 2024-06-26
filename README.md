# AWS ECommerce Project

This is a personal ECommerce project developed to demonstrate the usage of Amazon Web Services (AWS) in building a distributed application.

## Overview

The project utilizes various AWS services to simulate an order flow in an ECommerce application. It includes:

- **AWS Lambda**: Three Lambda functions are used for different parts of the process, including customer registration, order creation, order approval, and invoice generation.
  
- **AWS SQS (Simple Queue Service)**: Three SQS queues are utilized in the project, one for created orders, one for paid orders, and a dead-letter queue (DLQ) to handle messages with problems.

- **AWS DynamoDB**: The NoSQL database DynamoDB is used to store information about customers, orders, and invoices.

- **AWS S3 (Simple Storage Service)**: The S3 object storage service is used to store invoice files generated by the system.

- **AWS API Gateway**: The API Gateway is used to expose HTTP endpoints for the Lambda functions.

## Main Features

### Customer Registration

- HTTP endpoint for creating, reading, updating, and deleting customers.

### Order Creation

- When an order is created, it is sent to a queue of created orders (Created Orders). A dead-letter queue (DLQ) is configured to handle messages with problems, ensuring they are not lost or stuck in a loop.

### Order Approval

- A Lambda function is triggered by SQS to approve the orders received in the Created Orders queue. After approval, the order is recorded in DynamoDB, and a message is published to the Paid Orders queue.

### Invoice Generation

- A third Lambda function listens to the Paid Orders queue and generates an invoice for each approved order. The invoice is stored in DynamoDB, and the corresponding file is saved in S3. An endpoint is available to download the invoice associated with an order.

## Scalability and Resilience

The project is developed with a focus on decoupling and scalability, allowing different parts of the process to be scaled independently as demand changes. The use of SQS queues and Lambda functions facilitates asynchronous and distributed processing of orders, ensuring high availability and resilience.

## How to Run the Project

1. Clone this repository to your local machine.
2. Configure your AWS credentials in the `~/.aws/credentials` configuration file.
3. Install project dependencies if necessary.
4. Deploy the Lambda functions and create the SQS queues, DynamoDB table, and S3 bucket using the AWS Console or AWS CLI.
5. Configure the Lambda function triggers as described in the "Main Features" section.
6. Test the project using the HTTP endpoints exposed by the API Gateway.

## Contribution

Contributions are welcome! Feel free to open an issue or submit a pull request with improvements, bug fixes, or new features.

## License

This project is licensed under the [MIT License](LICENSE).
