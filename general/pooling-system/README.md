# Simple Pooling System

This example is pulled from [this source](https://www.youtube.com/watch?v=uxm4a0QnQ9E). It
demonstrates how a simple object pooling can be created to re-use existing
game objects instead of destroying them, and thus avoids unnecessary
garbage collection.

Garbage collection isn't usually a big deal on PCs and Laptops, but can be
very noticeable on mobile platforms where computing power is limited. This
principle even extends to larger platforms for large-scale games. When
the garage collector runs, it may cause a number of frames to be dropped.
