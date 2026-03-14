// See https://aka.ms/new-console-template for more information
public class KodePos {
    public enum Keluarahan { Batunuggal, Kujangsari, Mengger, Wates, Cijaura, Jatisari, Margasari, Sekejati, Kebonwaru, Maleer}
    public static int getKodePos(Keluarahan keluarahan) {
        int[] kodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274};
        return kodePos[(int)keluarahan];
    }
}
public class main {
    static void Main() {

        string[] keluarahanNames = Enum.GetNames(typeof(KodePos.Keluarahan));

        Console.WriteLine("Daftar Keluarahan Beserta Kode Pos");

        for (int i = 0; i < keluarahanNames.Length; i++)
        {
            KodePos.Keluarahan kel = (KodePos.Keluarahan)Enum.Parse(typeof(KodePos.Keluarahan), keluarahanNames[i]);

            int kodepos = KodePos.getKodePos(kel);

            Console.WriteLine("Kelurahan: {0} | Kode Pos: {1}", kel, kodepos);
        }
    }
}