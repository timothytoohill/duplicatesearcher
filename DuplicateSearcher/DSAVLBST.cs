namespace DuplicateSearcher {
    using System;
    using System.Collections.Generic;
    using System.Collections;

    /* collection of IComparables that are structured as an AVL binary tree. */
    public sealed class DSAVLBST<T> where T : IComparable<T> {
        // all members 
        private Node root;
        private int count;


        //all properties
        /* get count property */
        public int Count { get { return count; } }

        /* returns the root node */
        public Node Root { get { return root; } }


        //all public methods
        /* add an item */
        public bool Add(T item) {
            if (item == null) {
                throw new ArgumentNullException();
            }

            /* set out first node to the root */
            Node p = root;

            /* start working down the tree to see where it should be added */
            if (p == null) {
                root = new Node(item);
            } else {
                while (true) {
                    int c = item.CompareTo(p.Item);
                    if (c < 0) {
                        if (p.Left != null) {
                            p = p.Left;
                        } else {
                            p.Left = new Node(item, p);
                            p.Balance--;
                            break;
                        }
                    } else if (c > 0) {
                        if (p.Right != null) {
                            p = p.Right;
                        } else {
                            p.Right = new Node(item, p);
                            p.Balance++;
                            break;
                        }
                    } else {
                        return false;
                    }
                }

                /* rebalance */
                while ((p.Balance != 0) && (p.Parent != null)) {
                    if (p.Parent.Left == p) {
                        p.Parent.Balance--;
                    } else {
                        p.Parent.Balance++;
                    }

                    p = p.Parent;

                    if (p.Balance == -2) {
                        Node x = p.Left;
                        if (x.Balance == -1) {
                            x.Parent = p.Parent;

                            if (p.Parent == null) {
                                root = x;
                            } else {
                                if (p.Parent.Left == p) {
                                    p.Parent.Left = x;
                                } else {
                                    p.Parent.Right = x;
                                }
                            }

                            p.Left = x.Right;

                            if (p.Left != null) {
                                p.Left.Parent = p;
                            }

                            x.Right = p;
                            p.Parent = x;

                            x.Balance = 0;
                            p.Balance = 0;
                        } else {
                            Node w = x.Right;

                            w.Parent = p.Parent;

                            if (p.Parent == null) {
                                root = w;
                            } else {
                                if (p.Parent.Left == p) {
                                    p.Parent.Left = w;
                                } else {
                                    p.Parent.Right = w;
                                }
                            }

                            x.Right = w.Left;

                            if (x.Right != null) {
                                x.Right.Parent = x;
                            }

                            p.Left = w.Right;

                            if (p.Left != null) {
                                p.Left.Parent = p;
                            }

                            w.Left = x;
                            w.Right = p;
                            x.Parent = w;
                            p.Parent = w;

                            if (w.Balance == -1) {
                                x.Balance = 0;
                                p.Balance = 1;
                            } else if (w.Balance == 0) {
                                x.Balance = 0;
                                p.Balance = 0;
                            } else {
                                x.Balance = -1;
                                p.Balance = 0;
                            }

                            w.Balance = 0;
                        }

                        break;
                    } else if (p.Balance == 2) {
                        Node x = p.Right;

                        if (x.Balance == 1) {
                            x.Parent = p.Parent;

                            if (p.Parent == null) {
                                root = x;
                            } else {
                                if (p.Parent.Left == p) {
                                    p.Parent.Left = x;
                                } else {
                                    p.Parent.Right = x;
                                }
                            }

                            p.Right = x.Left;

                            if (p.Right != null) {
                                p.Right.Parent = p;
                            }

                            x.Left = p;
                            p.Parent = x;
                            x.Balance = 0;
                            p.Balance = 0;
                        } else {
                            Node w = x.Left;

                            w.Parent = p.Parent;

                            if (p.Parent == null) {
                                root = w;
                            } else {
                                if (p.Parent.Left == p) {
                                    p.Parent.Left = w;
                                } else {
                                    p.Parent.Right = w;
                                }
                            }

                            x.Left = w.Right;

                            if (x.Left != null) {
                                x.Left.Parent = x;
                            }

                            p.Right = w.Left;

                            if (p.Right != null) {
                                p.Right.Parent = p;
                            }

                            w.Right = x;
                            w.Left = p;
                            x.Parent = w;
                            p.Parent = w;

                            if (w.Balance == 1) {
                                x.Balance = 0;
                                p.Balance = -1;
                            } else if (w.Balance == 0) {
                                x.Balance = 0;
                                p.Balance = 0;
                            } else {
                                x.Balance = 1;
                                p.Balance = 0;
                            }

                            w.Balance = 0;
                        }

                        break;
                    }
                }
            }

            count++;

            return true;
        }

        /* clear the whole collection */
        public void Clear() {
            Node n = root;

            /* loop over the nodes until the least is reached */
            while (n != null) {
                n.Item = default(T);

                while (n.Left != null) {
                    n = n.Left;
                }

                /* nullify the rightmost and move on */
                if (n.Right == null) {
                    if (n.Parent == null) {
                        break;
                    } else {
                        if (n.Parent.Left == n) {
                            n = n.Parent;
                            n.Left = null;
                        } else {
                            n = n.Parent;
                            n.Right = null;
                        }
                    }
                } else {
                    n = n.Right;
                }
            }
            
            root = null;
            count = 0;
        }

        /* determins if the object is already in the colletion (uses the compareto ) */
        public bool Contains(T item) {
            if (item == null) {
                throw new ArgumentNullException();
            }

            Node p = root;

            while (p != null) {
                int c = item.CompareTo(p.Item);

                if (c < 0) {
                    p = p.Left;
                } else if (c > 0) {
                    p = p.Right;
                } else {
                    return true;
                }
            }

            return false;
        }

        /* similar to the contains method, except that the object (if it is found) is returned */
        public T Find(T item) {
            if (item == null) {
                throw new ArgumentNullException();
            }

            Node p = root;

            while (p != null) {
                int c = item.CompareTo(p.Item);
                if (c < 0) {
                    p = p.Left;
                } else if (c > 0) {
                    p = p.Right;
                } else {
                    return p.Item;
                }
            }

            return default(T);
        }

        /* copies the whole collection to an array */
        public void CopyTo(T[] array, int index) {
            if (array == null) {
                throw new ArgumentNullException();
            }

            if ((index < 0) || (index >= array.Length)) {
                throw new ArgumentOutOfRangeException();
            }

            if ((array.Length - index) < count) {
                throw new ArgumentException();
            }

            Node p = root;

            if (p == null) {
                return;
            }

            while (p.Left != null) {
                p = p.Left;
            }

            while (true) {
                array[index] = p.Item;

                if (p.Right == null) {
                    while (true) {
                        if (p.Parent == null) {
                            return;
                        }

                        if (p != p.Parent.Right) {
                            break;
                        }

                        p = p.Parent;
                    }

                    p = p.Parent;
                } else {
                    p = p.Right;

                    while (p.Left != null) {
                        p = p.Left;
                    }
                }

                index++;
            }
        }

        /* returns an array of type Ts */
        public T[] ToArray() {
            T[] array = new T[count];
            if (count > 0) 
                CopyTo(array, 0);

            return array;
        }

        /* gets the enumerator */
        public AscendingOrderEnumerator GetEnumerator() {
            Node p = root;

            if (p != null) {
                while (p.Left != null) {
                    p = p.Left;
                }
            }

            return new AscendingOrderEnumerator(p);
        }

        /* removes an item from the collection */
        public bool Remove(T item) {
            if (item == null) {
                throw new ArgumentNullException();
            }

            Node p = root;

            while (p != null) {
                int c = item.CompareTo(p.Item);

                if (c < 0) {
                    p = p.Left;
                } else if (c > 0) {
                    p = p.Right;
                } else {
                    Node y;

                    if (p.Right == null) {
                        if (p.Left != null) {
                            p.Left.Parent = p.Parent;
                        }

                        if (p.Parent == null) {
                            root = p.Left;
                            goto Done;
                        }

                        if (p == p.Parent.Left) {
                            p.Parent.Left = p.Left;
                            y = p.Parent;
                        } else {
                            p.Parent.Right = p.Left;
                            y = p.Parent;
                            goto RightDelete;
                        }
                    } else if (p.Right.Left == null) {
                        if (p.Left != null) {
                            p.Left.Parent = p.Right;
                            p.Right.Left = p.Left;
                        }

                        p.Right.Balance = p.Balance;
                        p.Right.Parent = p.Parent;

                        if (p.Parent == null) {
                            root = p.Right;
                        } else {
                            if (p == p.Parent.Left) {
                                p.Parent.Left = p.Right;
                            } else {
                                p.Parent.Right = p.Right;
                            }
                        }

                        y = p.Right;

                        goto RightDelete;
                    } else	{
                        Node s = p.Right.Left;

                        while (s.Left != null) {
                            s = s.Left;
                        }

                        if (p.Left != null) {
                            p.Left.Parent = s;
                            s.Left = p.Left;
                        }

                        s.Parent.Left = s.Right;

                        if (s.Right != null) {
                            s.Right.Parent = s.Parent;
                        }

                        p.Right.Parent = s;
                        s.Right = p.Right;
                        y = s.Parent;
                        s.Balance = p.Balance;
                        s.Parent = p.Parent;

                        if (p.Parent == null) {
                            root = s;
                        } else {
                            if (p == p.Parent.Left) {
                                p.Parent.Left = s;
                            } else {
                                p.Parent.Right = s;
                            }
                        }
                    }

                    LeftDelete:

                    y.Balance++;

                    if (y.Balance == 1) {
                        goto Done;
                    } else if (y.Balance == 2) {
                        Node x = y.Right;

                        if (x.Balance == -1) {
                            Node w = x.Left;

                            w.Parent = y.Parent;

                            if (y.Parent == null) {
                                root = w;
                            } else {
                                if (y.Parent.Left == y) {
                                    y.Parent.Left = w;
                                } else {
                                    y.Parent.Right = w;
                                }
                            }

                            x.Left = w.Right;

                            if (x.Left != null) {
                                x.Left.Parent = x;
                            }

                            y.Right = w.Left;

                            if (y.Right != null) {
                                y.Right.Parent = y;
                            }

                            w.Right = x;
                            w.Left = y;
                            x.Parent = w;
                            y.Parent = w;

                            if (w.Balance == 1) {
                                x.Balance = 0;
                                y.Balance = -1;
                            } else if (w.Balance == 0) {
                                x.Balance = 0;
                                y.Balance = 0;
                            } else {
                                x.Balance = 1;
                                y.Balance = 0;
                            }

                            w.Balance = 0;
                            y = w; 
                        } else {
                            x.Parent = y.Parent;

                            if (y.Parent != null) {
                                if (y.Parent.Left == y) {
                                    y.Parent.Left = x;
                                } else {
                                    y.Parent.Right = x;
                                }
                            } else {
                                root = x;
                            }

                            y.Right = x.Left;

                            if (y.Right != null) {
                                y.Right.Parent = y;
                            }

                            x.Left = y;
                            y.Parent = x;

                            if (x.Balance == 0) {
                                x.Balance = -1;
                                y.Balance = 1;

                                goto Done;
                            } else {
                                x.Balance = 0;
                                y.Balance = 0;

                                y = x; 
                            }
                        }
                    }

                    goto LoopTest;

                    RightDelete:

                    y.Balance--;

                    if (y.Balance == -1) {
                        goto Done;
                    } else if (y.Balance == -2) {
                        Node x = y.Left;

                        if (x.Balance == 1) {
                            Node w = x.Right;

                            w.Parent = y.Parent;

                            if (y.Parent == null) {
                                root = w;
                            } else {
                                if (y.Parent.Left == y) {
                                    y.Parent.Left = w;
                                } else {
                                    y.Parent.Right = w;
                                }
                            }

                            x.Right = w.Left;

                            if (x.Right != null) {
                                x.Right.Parent = x;
                            }

                            y.Left = w.Right;

                            if (y.Left != null) {
                                y.Left.Parent = y;
                            }

                            w.Left = x;
                            w.Right = y;

                            x.Parent = w;
                            y.Parent = w;

                            if (w.Balance == -1) {
                                x.Balance = 0;
                                y.Balance = 1;
                            } else if (w.Balance == 0) {
                                x.Balance = 0;
                                y.Balance = 0;
                            } else {
                                x.Balance = -1;
                                y.Balance = 0;
                            }

                            w.Balance = 0;
                            y = w; 
                        } else {
                            x.Parent = y.Parent;

                            if (y.Parent != null) {
                                if (y.Parent.Left == y) {
                                    y.Parent.Left = x;
                                } else {
                                    y.Parent.Right = x;
                                }
                            } else {
                                root = x;
                            }

                            y.Left = x.Right;

                            if (y.Left != null) {
                                y.Left.Parent = y;
                            }

                            x.Right = y;
                            y.Parent = x;

                            if (x.Balance == 0) {
                                x.Balance = 1;
                                y.Balance = -1;

                                goto Done;
                            } else {
                                x.Balance = 0;
                                y.Balance = 0;
                                y = x;
                            }
                        }
                    }

                    LoopTest:

                    if (y.Parent != null) {
                        if (y == y.Parent.Left) {
                            y = y.Parent;
                            goto LeftDelete;
                        }

                        y = y.Parent;
                        goto RightDelete;
                    }

                    Done:

                    count--;
                    return true;
                }
            }

            return false;
        }


        //interal classes
        /* used internally to represent and organize the nodes of the tree */
        public class Node {
            //all members
            public T Item;
            public Node Parent;
            public Node Left;
            public Node Right;
            public sbyte Balance;

            /* constructor for the node class */
            public Node(T item) {
                Item = item;
            }

            /* another constructor */
            public Node(T item, Node parent) {
                Item = item;
                Parent = parent;
            }
        }

        /* enumerator */
        public struct AscendingOrderEnumerator : IEnumerator<T> {
            private Node next;
            private T current;

            /* current property ?*/
            object IEnumerator.Current { get { return current; } }
            public T Current {
                get {
                    return current;
                }
            }

            /* constructor */
            public AscendingOrderEnumerator(Node node) {
                next = node;
                current = default(T);
            }

            /* go next */
            public bool MoveNext() {
                if (next == null) {
                    return false;
                }

                current = next.Item;

                if (next.Right == null) {
                    while ((next.Parent != null) && (next == next.Parent.Right)) {
                        next = next.Parent;
                    }

                    next = next.Parent;
                } else {
                    next = next.Right;

                    while (next.Left != null) {
                        next = next.Left;
                    }
                }

                return true;
            }

            /* reset collection */
            void IEnumerator.Reset() {
                throw new NotSupportedException();
            }

            /* must be implemented */
            public void Dispose() { }
        }
    }
}