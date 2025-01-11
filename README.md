# `fuzzierinter`

fuzzierinter is a *fuzzy* search engine that only shows what you want.

## Getting Started

Go to [FI's website](https://mariluski23.github.io/fuzzierinter/) and start searching!

### Syntax

- `IN "<website>"` Only search results from a specific website.
- `SEARCH "<query>"` Search for a word or phrase.
- `OR <query>` Search for a second thing.
- `AND <query>` Search for a second thing that must be in both the first and second query.
- `EXACT <str>` Search for an exact string.
- `NOT <query>` Exclude a word or phrase.
- `FROM <content / title / description>` Search only on the content, title or description of the page.
- `SORT <linked / date>` Sort the results by times linked or date.
- `ORDER <asc / desc>` Order the results in ascending or descending order.

> [!TIP]
> You can also search for a term in double quotes with no operators or modifiers to search it quickly.

### Examples

- `SORT linked IN "wikipedia.org" "Fuzzy searching"` Search for the term "Fuzzy searching" in wikipedia.org and sort the results by times linked.