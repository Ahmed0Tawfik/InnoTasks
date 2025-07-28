print("Task 13: Accept Until Negative")
numbers = [5, 10, 15, -3, 20]
for num in numbers:
    if num < 0:
        print("Negative number entered. Stopping.")
        break
    print(f"You entered: {num}") 