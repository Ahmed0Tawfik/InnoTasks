print("Task 17: Check Palindrome")
text = "madam"
cleaned_text = ''.join(char.lower() for char in text if char.isalnum())
if cleaned_text == cleaned_text[::-1]:
    print("The string is a palindrome")
else:
    print("The string is not a palindrome") 