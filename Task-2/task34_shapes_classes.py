import math

print("Task 34: Shapes Classes")
class Shape:
    def area(self):
        pass
    
    def perimeter(self):
        pass

class CircleShape(Shape):
    def __init__(self, radius):
        self.radius = radius
    
    def area(self):
        return math.pi * self.radius ** 2
    
    def perimeter(self):
        return 2 * math.pi * self.radius

class Triangle(Shape):
    def __init__(self, a, b, c):
        self.a = a
        self.b = b
        self.c = c
    
    def area(self):
        s = (self.a + self.b + self.c) / 2
        return math.sqrt(s * (s - self.a) * (s - self.b) * (s - self.c))
    
    def perimeter(self):
        return self.a + self.b + self.c

class Square(Shape):
    def __init__(self, side):
        self.side = side
    
    def area(self):
        return self.side ** 2
    
    def perimeter(self):
        return 4 * self.side

print("Testing different shapes:")
radius = 6.0
circle = CircleShape(radius)
print(f"Circle - Area: {circle.area():.2f}, Perimeter: {circle.perimeter():.2f}")

a = 3.0
b = 4.0
c = 5.0
triangle = Triangle(a, b, c)
print(f"Triangle - Area: {triangle.area():.2f}, Perimeter: {triangle.perimeter():.2f}")

side = 7.0
square = Square(side)
print(f"Square - Area: {square.area():.2f}, Perimeter: {square.perimeter():.2f}") 