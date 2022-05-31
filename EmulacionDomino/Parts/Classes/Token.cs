namespace Domino.Classes;
using Domino.Interfaces;
public class Token : IToken {

    int[] id;
    bool[] maskid;
    List<int> avalPos = new List<int>();
    int count = 0;
    public Token(int[] face){
        this.id = face;
        maskid = new bool[face.Count()]; 
        for(int i = 0; i < id.Length; i++) {
            avalPos.Add(id[i]);
        }
    }
    public IEnumerable< int > IDs{
        get{
            return id;
        }
    }
    public IEnumerable< int > AviablePositions{
        get{
            return avalPos;
        }
    }
    public int value {
        get {
            int total = 0;
            foreach( int item in id) {
                total += item;
            }
            return total;
        }
    }
    public void Play (int ID) {
        for( int i = 0; i < id.Length; i++ ) {
            if(id[i] == ID){
                maskid[i] = true;
                avalPos.RemoveAt(i - count);
                count ++;
            }
        }
    }

}
