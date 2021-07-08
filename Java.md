
`Module`   = Group of Packages
`Packages` = Group of classes
`Class`    = Basic unit of code


# Java APIs

## Java Streams APIs
* Use to filter, map and reduce large streams of data
* They perform actions upon data using lambda expressions
* Lambda expressions are a form of functional programming

```java
List<Employee> employees = new ArrayList<>();
employees.stream().parallel()
            .filter(e->e.getSallary())>1000)
            .forEach(e->e.calculateBonus());
```

## Java IO API
* Transfer data through a series of interconnected streams.
* Read information from various sources - input direction.
* Write information to various destinations - output direction.
 
## Java Concurrency API
* Takes advantage of multi-CPU-core architecture

## Java Persistence API
* Java Database Connectivity Protocol (JDBC) enables database connectivity and SQL statement execution
* Java Persistence API (JPA) enables Java object-relactional mappings

## Objects
* Each object has a unique object reference, a pointer to that object in memory.
* Each object has a pointer to its class definition.