# Maklad Language

The Maklad Language Development Project is a Project aimed at creating a new programming language  that combines simplicity, expressiveness, and efficiency .

# Index
1. [Declarations](#Declarations)
2. [Operators](#Operators)
    * [Arithmetic](#Arithmetic)
    * [Comparison](#Comparison)

4. [Functions](#Functions)
5. [Built-in Types](#Built-in)
6. [Control structures](#control-structures)
    * [If](#if)
    * [For](#loops)
    * [While](#loops)

7. [List](list)
8. [Dictionary](#Dictionary)
    
9. [Errors Handling](#Errors-Handling)
10. [Printing](#Printing)
11. [Comment](#Comment)
12. [Class](#Class)
13. [My Application Overview](#My-Application)


## Declarations

```Maklad
int x = 10
float y = 3.14 
string message = "Hello, World!"
```



## Operators
### Arithmetic
|Operator|Description|
|--------|-----------|
|`+`|addition|
|`-`|subtraction|
|`*`|multiplication|
|`/`|quotient|
|`%`|remainder|
|`^`|bitwise xor|


### Comparison
|Operator|Description|
|--------|-----------|
|`==`|equal|
|`!=`|not equal|
|`<`|less than|
|`<=`|less than or equal|
|`>`|greater than|
|`>=`|greater than or equal|



## Functions
```Maklad
func greet(name) {
    write("Hello, " + name)
}

greet("Maklad")
```


## Built-in Types
```Maklad
string
int
float
```


### If
```Maklad
if (x > y) {
    write("x is greater than y")
} else {
    write("y is greater than x")
}

```

### Loops
there are many ways to indentfy the steps you take the first foemat is increasing it ot decreasing it by one  `++i` , `--i` or `i++` , `i--` or the step depend on mathematical operation ` i +=1` ,  ` i -=1` , ` i *=1` , ` i /=1` 
```Maklad
for (int i = 0 to 10, ++i) {
    print(i)
}

int i = 0
while (i < 10) {
    print(i)
    ++i
}

```


## Dictionary and List

### List
```Maklad
int myList = [1, 2, 3, 4, 5]
float myList = [1.3, 2.69, 3.78, 4.46, 5.0]
string myList = ["Muhammed","Gamal","Maklad"]
```

### Dictionary
```Maklad
myDict = { "name": "Muhammed", "age": 20 }
```



## Errors-Handling 


```Maklad
try 
{
    @ Code that might throw an exception
} 
catch 
{
    @ Handle the exception
}

```
```Maklad
try 
{
    @ Code that might throw an exception
} 
catch 
{
    @ Handle the exception
}
end
{
    @final statment 
}
```

## Printing

```Maklad
write ( "Hello World!" )
write(x)
```

## Comment 
```Maklad
@ This is a comment
```

## Class

```Maklad
class Person {
    int age
    string name
    
    func greet() {
        print("Hello, my name is " + name)
    }
}

Person p = Person("Maklad", 20)
p.greet()

```
We can also `inherits` from another Class
```Maklad
class Student inherits Person {
    int grade
    
    func displayInfo() {
        print("Name: " + name + ", Grade: " + grade)
    }
}

Student s = Student("Gemmy", 18, 12)
s.displayInfo()

```

## My-Application
My application is a Windows Forms application built using the C# programming language and using calitha engine. It facilitates parsing of a custom language, allowing users to view lexemes and tokens generated during the parsing process.<br><br><br>

<p float="left">
  <img src="https://github.com/Muhammed-Maklad/PLD/assets/119490645/0e3d00ad-80e2-47f6-bbd5-c521c664ed6f" width="400" />
  <img src="https://github.com/Muhammed-Maklad/PLD/assets/119490645/4ba90c26-2fb6-4a6a-8b2d-fb6ef9b725c9" width="400" /> 
</p>

### How to Use
Enter your custom code into the text box.
Click the "Parse" button to initiate the parsing process.
The application will display the expected tokens in the list box.
The lexemes and their corresponding tokens will be shown in another list box.

## Features
* Text box for inputting custom code.
* List box to display expected token from user.
* List box to display lexemes and their corresponding tokens.
