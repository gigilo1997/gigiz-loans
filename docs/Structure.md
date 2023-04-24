# Loan Website

- [Loan Website](#loan-website)
  - [Login Page](#login-page)
    - [Login Page - Login Button Click](#login-page---login-button-click)
    - [Login Page - Register Button Click](#login-page---register-button-click)
  - [Register Page](#register-page)
    - [Register Page - Register Button Click](#register-page---register-button-click)
    - [Register Page - Login Button Click](#register-page---login-button-click)
  - [Loan List Page](#loan-list-page)
    - [Loan List Page - Get and Render Loans](#loan-list-page---get-and-render-loans)
    - [Loan List Page - Edit Button Click](#loan-list-page---edit-button-click)
    - [Loan List Page - Accept Button Click](#loan-list-page---accept-button-click)
    - [Loan List Page - Decline Button Click](#loan-list-page---decline-button-click)
    - [Loan List Page - Delete Button Click](#loan-list-page---delete-button-click)
  - [Loan Create Page](#loan-create-page)
    - [Loan Create Page - Create Button Click](#loan-create-page---create-button-click)
    - [Loan Create Page - Go To List Button Click](#loan-create-page---go-to-list-button-click)
  - [Loan Edit Page](#loan-edit-page)
    - [Loan Edit Page - Edit Button Click](#loan-edit-page---edit-button-click)

## Login Page

### Login Page - Login Button Click

```bash
curl -X 'POST' \
  'https://localhost:7000/api/Auth/GenerateToken' \
  -H 'accept: text/plain' \
  -H 'Content-Type: multipart/form-data' \
  -F 'UserName=admin' \
  -F 'Password=Admin123'
```

### Login Page - Register Button Click

> Redirect to Register Page

## Register Page

### Register Page - Register Button Click

```bash
curl -X 'POST' \
  'https://localhost:7000/api/User/RegisterUser' \
  -H 'accept: text/plain' \
  -H 'Content-Type: multipart/form-data' \
  -F 'UserName=Test' \
  -F 'Password=Test' \
  -F 'RepeatPassword=Test' \
  -F 'FirstName=Test' \
  -F 'LastName=Testovichi' \
  -F 'PersonalNumber=12312312312' \
  -F 'DateOfBirth=1990-10-10'
```

### Register Page - Login Button Click

> Redirect to Login Page

## Loan List Page

### Loan List Page - Get and Render Loans

```bash
curl -X 'GET' \
  'https://localhost:7000/api/Loan/GetLoans?Page=1&Limit=25' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjIzMzY0ZWMwLTZhZmQtNDE0NC03MDUzLTA4ZGI0Mzc1YzM4NyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhZG1pbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6IkFkbWluIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3VybmFtZSI6IkFkbWluIiwiZXhwIjoxNjgyMjg0NzEzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDAwIn0.CbdjbvMk0P2ty8iNdsi3h59H54C4BABWKzLK_Axw174'
```

### Loan List Page - Edit Button Click

> Redirect to Edit Page with Loan ID

### Loan List Page - Accept Button Click

```bash
curl -X 'PUT' \
  'https://localhost:7000/api/Loan/AcceptLoan/70e2735e-76de-444a-bd4a-b090835cf4ce' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjIzMzY0ZWMwLTZhZmQtNDE0NC03MDUzLTA4ZGI0Mzc1YzM4NyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhZG1pbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6IkFkbWluIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3VybmFtZSI6IkFkbWluIiwiZXhwIjoxNjgyMjg0NzEzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDAwIn0.CbdjbvMk0P2ty8iNdsi3h59H54C4BABWKzLK_Axw174'
```

### Loan List Page - Decline Button Click

```bash
curl -X 'PUT' \
  'https://localhost:7000/api/Loan/DeclineLoan/70e2735e-76de-444a-bd4a-b090835cf4ce' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjIzMzY0ZWMwLTZhZmQtNDE0NC03MDUzLTA4ZGI0Mzc1YzM4NyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhZG1pbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6IkFkbWluIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3VybmFtZSI6IkFkbWluIiwiZXhwIjoxNjgyMjg0NzEzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDAwIn0.CbdjbvMk0P2ty8iNdsi3h59H54C4BABWKzLK_Axw174'
```

### Loan List Page - Delete Button Click

```bash
curl -X 'DELETE' \
  'https://localhost:7000/api/Loan/DeleteLoan/70e2735e-76de-444a-bd4a-b090835cf4ce' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjIzMzY0ZWMwLTZhZmQtNDE0NC03MDUzLTA4ZGI0Mzc1YzM4NyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhZG1pbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6IkFkbWluIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3VybmFtZSI6IkFkbWluIiwiZXhwIjoxNjgyMjg0NzEzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDAwIn0.CbdjbvMk0P2ty8iNdsi3h59H54C4BABWKzLK_Axw174'
```

## Loan Create Page

### Loan Create Page - Create Button Click

```bash
curl -X 'POST' \
  'https://localhost:7000/api/Loan/CreateLoan' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjIzMzY0ZWMwLTZhZmQtNDE0NC03MDUzLTA4ZGI0Mzc1YzM4NyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhZG1pbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6IkFkbWluIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3VybmFtZSI6IkFkbWluIiwiZXhwIjoxNjgyMjg0NzEzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDAwIn0.CbdjbvMk0P2ty8iNdsi3h59H54C4BABWKzLK_Axw174' \
  -H 'Content-Type: multipart/form-data' \
  -F 'Type=Auto' \
  -F 'Amount=100' \
  -F 'Currency=EUR' \
  -F 'DurationDays=3' \
  -F 'DurationMonths=6' \
  -F 'DurationYears=9'
```

### Loan Create Page - Go To List Button Click

> Redirect to Loans List Page

## Loan Edit Page

### Loan Edit Page - Edit Button Click

```bash
curl -X 'PUT' \
  'https://localhost:7000/api/Loan/EditLoan' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjIzMzY0ZWMwLTZhZmQtNDE0NC03MDUzLTA4ZGI0Mzc1YzM4NyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhZG1pbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6IkFkbWluIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3VybmFtZSI6IkFkbWluIiwiZXhwIjoxNjgyMjg0NzEzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDAwIn0.CbdjbvMk0P2ty8iNdsi3h59H54C4BABWKzLK_Axw174' \
  -H 'Content-Type: multipart/form-data' \
  -F 'Id=70e2735e-76de-444a-bd4a-b090835cf4ce' \
  -F 'Type=Fast' \
  -F 'Amount=100' \
  -F 'Currency=USD' \
  -F 'DurationDays=10' \
  -F 'DurationMonths=10' \
  -F 'DurationYears=10'
```
