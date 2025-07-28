print("Task 20: Kth Largest")
numbers = [10, 5, 8, 12, 3, 15]
k = 3
sorted_numbers = sorted(numbers, reverse=True)
if k <= len(sorted_numbers):
    print(f"{k}th largest element: {sorted_numbers[k-1]}")
else:
    print("k is out of range") 