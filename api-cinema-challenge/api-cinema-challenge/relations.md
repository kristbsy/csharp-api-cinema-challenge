# Relations

Customer:
  - Has many tickets

Movie:
  - Has many screenings

Screenings:
  - Has one Movie
  - Has many tickets

Tickets:
  - Has one Screening
  - Has one Customer
