# Terraform

- The `profile` attribute int your provider block refers Terraform to the AWS credential stored in your AWS Config File.

- The `resource` block refers to a infraestructure piece such as a EC2 instance or a Heroku application

# Commands

## `terraform init`
  * Downloads and install providers used in the configuration, which in this case is the aws provider 

## `terraform fmt`
  * Automatically updates configurations in the current directory for easy readability and consistency.

## `terraform validate`
  * Checks and reports errors within modules, attribute names, and value types
## ?
*  Open terraform console

> `terraform console` (Remeber to run `terraform init` before this) 

* Run a terraform plan
  
> `terraform apply`
  
  this is a shortcut for:
> `terraform plan -out file; terraform apply file; rm file`

Recommended approach: 
> `terraform plan -out file`
  
> `terraform apply file`

## Terraform loads variables in the following order, with later sources taking precedence over earlier ones:

* Environment variables
* The terraform.tfvars file, if present.
* The terraform.tfvars.json file, if present.
* Any *.auto.tfvars or *.auto.tfvars.json files, processed in lexical order of their filenames.
* Any -var and -var-file options on the command line, in the order they are provided. (This includes variables set by a Terraform Cloud workspace.)




# How To's


- Show list of resources in the state
  - > `terraform state list`

- Update the state file
  - > `terraform refresh`

- Using command line flags to provide variables:
   > `terraform appply -var="region=us-east-1"`

- Set the `.tfvars` that will be used
   > `terraform apply -var-file="sensitive.tfvars"`