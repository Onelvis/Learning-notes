# IAM, Identity Access Management

## Critical terms
---
* Users - End Users (people), A user can:
  * Be member of a group
  * Have policies attached directly
* Groups - A *collection of users* under one **set of permissions**. A way to group our users and apply policies to them collectively
* Roles - You create roles and can then ***assign*** them to AWS resources, **Is a set of policies**. You can assign roles to:
  * Applications running on EC2 instances
  * An AWS service that needs to act on resources in your account to provide its features
  * Users from a corporate directory who use identity federation with SAML
* Policies - A document that defines one (or more) permissions. When attached to an entity, the latter will have the permissions defined in the policy. Can be **Attached** to:
  * A user
  * A group
  * A role
    
    Also, polocies are defined in `JSON` format


## Characteristics
---
* IAM Is `global` (across all regions)
* The `root account` is the account created when first setup your AWS account. It has complete Admin access
* New users have **No permissions**