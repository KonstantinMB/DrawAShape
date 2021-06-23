# DrawAShape
The main goal of this project is to learn and use all OOP principles and provide a user friendly application for drawing different types of shapes!

While developing this university project, I learned and implemented these concepts:

1. Woking with the .NET Framework
2. The 4 pillarts of OOP (Inheritance, Encapsulation, Abstraction, Polymorphism)
3. How & when to use interfaces
4. The main functions in the Windows Forms Application toolkit
5. Working with 2D arrays/Point location (X,Y)
6. Serialization and how to open & save files on your machine
7. Working with libraries
8. Error handling
9. Debugging 

Next up are some pictures and GIFs of my project and how it basically works:

First off, when you open the app it will be blank with some buttons/text here and there.
- On the right-hand side you need to choose which shape you want to draw!
- In the upper-left corner, there is an 'Edit' strip, which opens a menu with different functions that the program can do.
- In the bottom-left corner, the total area of the shapes, drawn on the graphic is shown.

Here, you can see how the shapes are actually drawn. By dragging your mouse up/right/down/left.

The rectangle/square:

![first_gif_vol1](https://user-images.githubusercontent.com/76811860/123093597-8d5cf700-d434-11eb-88cf-8cefd1de91ff.gif)

The triangle:

![first_gif_vol2](https://user-images.githubusercontent.com/76811860/123093801-c5643a00-d434-11eb-8afb-4ae460d599a8.gif)

The circle:

![first_gif_vol3](https://user-images.githubusercontent.com/76811860/123093908-ec227080-d434-11eb-9ca8-21520593868c.gif)


Furthermore, the beauty of this program comes when we look at its functionalities!

1) You are able to tap on a shape and drag it wherever you want:
- if you drag it outside the window and leave it there, the Total Area will exclude this shape
- if you drag the triangle outside the window, an error window will pop, telling ou that you cannot do that.
- 
![second_vol1](https://user-images.githubusercontent.com/76811860/123099583-fd6e7b80-d43a-11eb-97e8-f0d891bde6b9.gif)

2) When you double click on a certain shape, new windows pops up and it allows you to change the shapes size & color. It also shows its parameter and area:
- if you change the color to white, an error will be trown because if the shape is white, it will be basically invisible :)
- changing the area & parameter isn't available
- if you don't type a number in the size sections (width, height, radius..) OR you type negative number, the program will trow an user friendly error too!

![second_vol2](https://user-images.githubusercontent.com/76811860/123099654-1119e200-d43b-11eb-9cbd-131b14502493.gif)

3) If you click on the Rectangle radio button and drag your mouse with its left key, you will only make the frame of the rectangle and with that select multiple shapes at once!

![second_vol3](https://user-images.githubusercontent.com/76811860/123099723-1f67fe00-d43b-11eb-9b99-95d1a175be82.gif)

4) The 'Edit' button will drop a menu (as you can see from the gif) and on it you will have these options:
- you can delete the selected shapes
- you can see the property of the selected shape
- search shapes by color
- 'Save' allows you to save the current file on your machine
- 'Open' opens a saved file on the app (if you try and open file of other type, the program will throw an error)

![second_vol4](https://user-images.githubusercontent.com/76811860/123099783-2d1d8380-d43b-11eb-9730-7bac2d429007.gif)

5)If you select a shape or a number of shapes, by clicking the 'Del' button on your keyboard, you will delete the selected shape/s.

6) When you make a shape on top of another shape OR you drag an existing shape onto another one, the Total Area of all shapes(shown in the bottom left) will remove the area of the overriden bit of the shapes.

![second_vol5](https://user-images.githubusercontent.com/76811860/123099833-37d81880-d43b-11eb-9677-78fa76056aad.gif)

