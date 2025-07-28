print("Task 16: Count Case")
text = "The quick Brow Fox"
upper_count = sum(1 for char in text if char.isupper())
lower_count = sum(1 for char in text if char.islower())
print(f"No. of Upper case characters: {upper_count}")
print(f"No. of Lower case Characters: {lower_count}") 