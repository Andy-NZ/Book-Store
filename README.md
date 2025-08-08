# dotnet run

--- Add Book ---
- Add new book <br/>
  Title: Book A, ISBN: 978-0-306-40615-7 <br/>
  New book: Id: 30feb1c6-d929-43ad-a324-c1727078860e, Title: Book A, ISBN: 978-0-306-40615-7 <br/>
Successfull!

--- Update Book ---
- Add new book <br/>
  Title: Book B, ISBN: 978-0-306-40615-7 <br/>
  New book: Id: b73f483d-586f-454f-8ee2-569b73251345, Title: Book B, ISBN: 978-0-306-40615-7 <br/>
- Update book <br/>
  book.Title = 'Book C' <br/>
- After updated <br/>
  Id: b73f483d-586f-454f-8ee2-569b73251345, Title: Book C, ISBN: 978-0-306-40615-7 <br/>
Successfull!

--- Get Book By Id ---
- Add new book <br/>
  Title: Book B, ISBN: 978-0-306-40615-7 <br/>
  New book: Id: a5b17e63-8c55-4bbd-9a07-56e6536bb336, Title: Book B, ISBN: 978-0-306-40615-7 <br/>
- GetBookById a5b17e63-8c55-4bbd-9a07-56e6536bb336 <br/>
  Return: Id: a5b17e63-8c55-4bbd-9a07-56e6536bb336, Title: Book B, ISBN: 978-0-306-40615-7 <br/>
Successfull!

--- Delete Book ---
- Add new book <br/>
  Title: Book B, ISBN: 978-0-306-40615-7 <br/>
  New book: Id: 5149e0ea-78ff-4439-8ceb-10d6c54fb697, Title: Book B, ISBN: 978-0-306-40615-7 <br/>
- DeleteBook 5149e0ea-78ff-4439-8ceb-10d6c54fb697 <br/>
Successfull!

--- List All Books ---
- bookService.ListAllBooks() <br/>
  Id: 30feb1c6-d929-43ad-a324-c1727078860e, Title: Book A, ISBN: 978-0-306-40615-7 <br/>
  Id: b73f483d-586f-454f-8ee2-569b73251345, Title: Book C, ISBN: 978-0-306-40615-7 <br/>
  Id: a5b17e63-8c55-4bbd-9a07-56e6536bb336, Title: Book B, ISBN: 978-0-306-40615-7 <br/>
Successfull!