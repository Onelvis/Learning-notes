# Linked list

- Linked list are physically represented in memory
- Each node is made of two parts: The data, and a pointer to the next node.
- The first node is the **head** and the last node is the **tail**. 
<br>
<br>
<br>

## Time complexity 
<br>

| Action | Average | Worst |
| ------ | ------  | ----- |
| Search | Θ(n) | O(n)|
| Insert | Θ(1) | O(1)|
| Delete | Θ(1) | O(1)|


# Doubly Linked list

They are like [Linked lists](linkedlist.md), but with an extra pointer that refers to the ***previous node***.


| Action | Average | Worst |
| ------ | ------  | ----- |
| Search | Θ(n) | O(n)|
| Insert | Θ(1) | O(1)|
| Delete | Θ(1) | O(1)|


# Balanced Trees
## Rotations
  
Given two nodes: A and B, A being the father of B.
  
### Right rotation 
  
Being A a father of B. A gains its child's right child as its new **left** child; and A becomes the new B's **right** child.
  
### Left rotation