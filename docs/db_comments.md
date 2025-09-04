## SQL vs NoSQL for Storing Comments
### SQL (relational DB)

✅ Pros:

- Relations are natural → 1 Post can have many comments. This is a classic **1-to-many** schema.
- Referential integrity → every comment must belong to a valid post, enforced by **foreign key**.
- Complex queries are powerful → **filtering** posts with most comments, joining with users, **pagination**, etc.
- Transactions → adding/deleting/updating comments is safe (**atomicity**).

❌ Cons:

- High write throughput can hurt → if I expect millions of comments (think Twitter scale), inserts + joins can slow down.
- Schema changes (like adding “likes” on comments later) require **migrations**.

### NoSQL (document DB like MongoDB, DynamoDB)

✅ Pros:

- Flexible schema → I can simply dump new fields (likes, replies, editedAt) without migrations.
- Scales horizontally → better suited if I expect comments to grow into millions per post.
- Denormalization → I can **embed comments** inside a post document, making fetching a single post with all its comments very fast.

❌ Cons:

- Data **duplication** → if comments exist in multiple contexts (user profile + post), **tricky updates**.
- No strict foreign keys → orphaned or **inconsistent data** possible if not handled in code.
- **Complex queries** are harder → things like “top 10 posts with most comments this week” are **trickier**.

👉 For this blog app scale, SQL is perfectly fine. NoSQL makes sense only if I want to simulate very high scale or learn distributed DBs. I might try that in a different branch.