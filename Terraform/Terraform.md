# Terraform

## Variable

```javascript
variable "AWS_REGION"{
    type = string
    default "default value"
}

```


## Provider

```
provider "provider name"{

}

```

## Resource

```typescript
resource "resource type" "name of resource"{
    ami = var.AMIS[var.AWS_REGION]
    //also: ami = "${var.AMIS[var.AWS_REGION]}"
    var a = `${}`
    instance_type = "t2.micro"

}

```



## Commands

*  Open terraform console
> `terraform console` (Remeber to run `terraform init` before this) 

* Run a terraform plan
  
>`terraform apply`
  
  this is a shortcut for:
> `terraform plan -out file; terraform apply file; rm file`

Recommended approuch: 
> `terraform plan -out file`
  
> `terraform apply file`