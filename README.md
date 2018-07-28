# AzurePassword
A password generator, geared towards Azure.

Available on [Azure](http://azurepassword.azurewebsites.net).

# REST Api
Simple REST Api, only GET requests.

By default, a password of length 14 is generated, which has:

1. At least one digit
2. At least one upper case letter
3. At least one lower case letter
4. At least one allowed symbol

The glory details

| Request        | Description  |
| -------------- |-------------|
| /generate  | Same as the default |
| /generate/**_len_** | The desired password length, **_len_** is integer. |
| /generate/**_len_**/**_upper_** | **_upper_** (true/false) controls whether to use upper case letters |
| /generate/**_len_**/**_upper_**/**_lower_** | **_lower_** (true/false) controls whether to use lower case letters |
| /generate/**_len_**/**_upper_**/**_lower_**/**_digits_** | **_digits_** (true/false) controls whether to use digits |
| /generate/**_len_**/**_upper_**/**_lower_**/**_digits_**/**_symbols_** | **_symbols_** (string) controls what symbols to use |
| /verify/**_password_** | Verifies a given password with respect to the above rules  |
