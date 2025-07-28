print("Task 24: Sort Dictionary")
sample_dict = {'a': 3, 'b': 1, 'c': 4, 'd': 2}
sorted_asc = dict(sorted(sample_dict.items(), key=lambda x: x[1]))
sorted_desc = dict(sorted(sample_dict.items(), key=lambda x: x[1], reverse=True))
print(f"Ascending: {sorted_asc}")
print(f"Descending: {sorted_desc}") 