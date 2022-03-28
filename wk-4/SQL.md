## Tables have relationships to one another.
one entry on a table may reference/be referenced by an entry on a different table
- many-to-1 - multiple entries in Table A will reference the same entry in Table B
- 1-to-many - one entry in table A references multiple entries in Table B
- 1-to-1 - an entry in table A references a single entry in table B
- many-to-many - multiple entries in Table A can reference multiple entries in Table B

Primary Key - a unique identifier for an entry/object. Must not be null.
Candidate Key - aything that could be a primary key (but isn't the Primary Key)
Composite Key - multiple values that can be used together to uniquely identify an entry/object


## Data can be organized into "Normal Forms"
- Un-Normalized is data that is un-organized, ineffecient, and generally difficult to use.
- 1st Normal Form - every entry has a key value to uniquely identify it, and all data is "Atomic"
- 2nd Normal Form - the primary key is not dependant on any subset of candidate key (look for duplicates!)
- 3rd Normal Form - No transitive dependencies (column a depends on column b; column b depends on column c; therefore a depends on c)
