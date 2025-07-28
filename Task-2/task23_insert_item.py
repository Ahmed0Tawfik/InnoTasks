print("Task 23: Insert Item")
items = ["bread", "milk", "eggs", "cheese", "apples", "bananas", "chicken", "rice", "tomatoes", "potatoes"]
new_item = "butter"
position = 3
items.insert(position - 1, new_item)
print("Updated list:")
for i, item in enumerate(items, 1):
    print(f"{i}. {item}") 