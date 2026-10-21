# IntNode

Practice with linked lists of `IntNode`. You write the functions from the
worksheet, press Run, and see which tests pass.

## How to do the exercise

1. Open **[Program.cs](https://raw.githubusercontent.com/jmagaram/IntNode/master/Program.cs)**.
2. Select all of it (Ctrl+A) and copy it (Ctrl+C).
3. Go to **[dotnetfiddle.net](https://dotnetfiddle.net)**, delete what's there,
   and paste (Ctrl+V).
4. Write the functions at the top of `Program`. Each one has a comment that
   says what it should do, numbered like the worksheet. 11b is a challenge.
5. Press **Run**. Each test prints `PASS` or `FAIL`, and the end shows
   your score for each question. Fix and run again until you pass all of them.

Don't change anything below the line that says
`Tests – don't change anything below this line`.

A test that says `CRASHED: NullReferenceException` means your code used a
node that was `null`. Check what happens with the empty list.

A result that says `never ends` means your list now loops back on itself.
Check which node each `SetNext` points to.

If Run seems to hang and then stops, there's probably a loop that never ends.
Check that you move to the next node with `lst = lst.GetNext();`.

## Running it on your own computer

With the [.NET SDK](https://dotnet.microsoft.com/download) installed:

```
dotnet run
```
