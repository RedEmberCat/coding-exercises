def add(a, b): return a + b
def sub(a, b): return a - b
def discr(a, b, c): return (b**2 - 4 * a * c)**(1/2)
def qe(a, b, c): return [f(-b, discr(a, b, c))/2/a for f in (add, sub)]
print(qe(2, 2, -12))  # expect [2.0, -3.0]
