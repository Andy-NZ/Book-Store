# dotnet run

--- Add Book ---
- Add new book
  Title: Book A, ISBN: 978-0-306-40615-7
  New book: Id: 30feb1c6-d929-43ad-a324-c1727078860e, Title: Book A, ISBN: 978-0-306-40615-7
Successfull!

--- Update Book ---
- Add new book
  Title: Book B, ISBN: 978-0-306-40615-7
  New book: Id: b73f483d-586f-454f-8ee2-569b73251345, Title: Book B, ISBN: 978-0-306-40615-7
- Update book
  book.Title = 'Book C'
- After updated
  Id: b73f483d-586f-454f-8ee2-569b73251345, Title: Book C, ISBN: 978-0-306-40615-7
Successfull!

--- Get Book By Id ---
- Add new book
  Title: Book B, ISBN: 978-0-306-40615-7
  New book: Id: a5b17e63-8c55-4bbd-9a07-56e6536bb336, Title: Book B, ISBN: 978-0-306-40615-7
- GetBookById a5b17e63-8c55-4bbd-9a07-56e6536bb336
  Return: Id: a5b17e63-8c55-4bbd-9a07-56e6536bb336, Title: Book B, ISBN: 978-0-306-40615-7
Successfull!

--- Delete Book ---
- Add new book
  Title: Book B, ISBN: 978-0-306-40615-7
  New book: Id: 5149e0ea-78ff-4439-8ceb-10d6c54fb697, Title: Book B, ISBN: 978-0-306-40615-7
- DeleteBook 5149e0ea-78ff-4439-8ceb-10d6c54fb697
Successfull!

--- List All Books ---
- bookService.ListAllBooks()
  Id: 30feb1c6-d929-43ad-a324-c1727078860e, Title: Book A, ISBN: 978-0-306-40615-7
  Id: b73f483d-586f-454f-8ee2-569b73251345, Title: Book C, ISBN: 978-0-306-40615-7
  Id: a5b17e63-8c55-4bbd-9a07-56e6536bb336, Title: Book B, ISBN: 978-0-306-40615-7
Successfull!