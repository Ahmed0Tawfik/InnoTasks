print("Task 4: Natural Numbers Pattern")
n = 5
for i in range(1, n + 1):
    sum_val = sum(range(1, i + 1))
    print(f"{'+'.join(map(str, range(1, i + 1)))} = {sum_val}") 