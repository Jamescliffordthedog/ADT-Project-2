using System;

namespace ADT_Project_2
{
    public class LinkedList
    {
        public Node? Head { get; set; };
        public int Count { get; set; };

        public LinkedList()
        {
            //When a new linked list is created the head will always be null
            Head = null;
            //Keeps track of the nodes in the list
            Count = 0;
        }

        public void DisplayPlaylist()
        {
            Node current = Head;
            int index = 1;

            if (Head == null)
            {
                Console.WriteLine("This playlist has no songs");
                return;
            }

            while (true)
            {
                Console.WriteLine(index + ". " + current.Data.displaySong() + "/n");
                current = current.Next!;
                index++;

                if (current == Head)
                    break;
            }
        }

        public void Add(Song song)
        {
            Node currentNode = new Node(song);

            if (Head == null)
            {
                Head = currentNode;
                Head.Next = Head;
                Head.Prev = Head;
            }
            else
            {
                Node tail = Head.prev;
                Head.Prev = currentNode;
                tail.Next = currentNode;
                currentNode.Next = Head;
                currentNode.Prev = tail;
            }

            Count++;
        }

        public bool RemoveByTitle(string title)
        {
            if (Head == null)
                return false;

            Node current = Head;

            do
            {
                if (current.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    if (current.Next == current && current.Prev == current)
                    {
                        Head = null;
                    }
                    else
                    {
                        current.Prev!.Next = current.Next;
                        current.Next!.Prev = current.Prev;

                        if (current == Head)
                            Head = current.Next;
                    }

                    Count--;
                    return true;
                }

                current = current.Next!;
            } while (current != Head);

            return false;
        }

        public bool DeleteByPosition(int position)
        {
            if (Head == null || position < 1 || position > Count)
                return false;

            Node current = Head;

            for (int i = 1; i < position; i++)
            {
                current = current.Next!;
            }

            if (current.Next == current && current.Prev == current)
            {
                Head = null;
            }
            else
            {
                current.Prev!.Next = current.Next;
                current.Next!.Prev = current.Prev;

                if (current == Head)
                    Head = current.Next;
            }

            Count--;
            return true;
        }

        public int SearchSong(string title)
        {
            if (Head == null)
                return -1;

            Node current = Head;
            int position = 1;

            do
            {
                if (current.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    return position;

                current = current.Next!;
                position++;
            } while (current != Head);

            return -1;
        }

        public void PlayAll()
        {
            if (Head == null)
            {
                Console.WriteLine("Playlist is empty.");
                return;
            }

            Node current = Head;

            do
            {
                Console.WriteLine($"Now Playing: {current.Data.displaySong()}");
                current = current.Next!;
            } while (current != Head);
        }

        public void Shuffle()
        {
            if (Head == null || Count < 2)
                return;

            var nodes = new List<Node>();
            Node current = Head;
            do
            {
                nodes.Add(current);
                current = current.Next!;
            } while (current != Head);

            Random rand = new Random();
            var shuffled = nodes.OrderBy(x => rand.Next()).ToList();

            for (int i = 0; i < shuffled.Count; i++)
            {
                var nextIndex = (i + 1) % shuffled.Count;
                var prevIndex = (i - 1 + shuffled.Count) % shuffled.Count;

                shuffled[i].Next = shuffled[nextIndex];
                shuffled[i].Prev = shuffled[prevIndex];
            }

            Head = shuffled[0];
        }
    }
}
