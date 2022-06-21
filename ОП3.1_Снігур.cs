void Kolo(int n)
{
    var startIndex = 0;
    var list = Enumerable.Range(1, n).ToList();
    Console.WriteLine("Початковий список:"  + string.Join(',', list));
    
    while (list.Count > 1)
    {
        for (var i = startIndex; i < list.Count; i+=1)
        {
            startIndex = (list.Count - 1 - i) == 1 ? 0 : 1; // Якщо останній елемент вичеркнуто, то починаємо з 2-го ел
                                                            // елементу нового списку
            Console.WriteLine(list[i]);
            list.RemoveAt(i);
        }
        Console.WriteLine("Cписок:"  + string.Join(',', list));
    }

    Console.WriteLine("Залишилось " + list.Count + " елементiв");
}

Kolo(15);