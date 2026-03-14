// See https://aka.ms/new-console-template for more information
public class KodePos {
    public enum Keluarahan { Batunuggal, Kujangsari, Mengger, Wates, Cijaura, Jatisari, Margasari, Sekejati, Kebonwaru, Maleer}
    public static int getKodePos(Keluarahan keluarahan) {
        int[] kodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274};
        return kodePos[(int)keluarahan];
    }
}

public class DoorMachine
{
    public enum DoorState { Terkunci, Terbuka };
    public enum Trigger { KunciPintu, BukaPintu }
    class transition
    {
        public DoorState prevState;
        public DoorState nextState;
        public Trigger trigger;
        public transition(DoorState currentState, DoorState nextState, Trigger trigger)
        {
            this.prevState = currentState;
            this.nextState = nextState;
            this.trigger = trigger;
        }
    }

    transition[] transitions = {
         new transition(DoorState.Terkunci, DoorState.Terbuka, Trigger.BukaPintu),
         new transition(DoorState.Terbuka, DoorState.Terkunci, Trigger.KunciPintu), 
         new transition(DoorState.Terkunci, DoorState.Terkunci, Trigger.KunciPintu),
         new transition(DoorState.Terbuka, DoorState.Terbuka, Trigger.BukaPintu)};

    public DoorState currentState;
    public DoorMachine()
    {
        currentState = DoorState.Terkunci;
    }
    public DoorState getNextState(DoorState prevState, Trigger trigger)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            if (transitions[i].prevState == prevState && transitions[i].trigger == trigger)
            {
                return transitions[i].nextState;
            }
        }
        return prevState;
    }

    public void activateTrigger(Trigger trigger)
    {
        currentState = getNextState(currentState, trigger);

        if (currentState == DoorState.Terkunci)
        {
            Console.WriteLine("Pintu terkunci");
        }
        else
        {
            Console.WriteLine("Pintu tidak terkunci");
        }
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

        Console.WriteLine("=======================================");
        Console.WriteLine("Contoh Penggunaan DoorMachine: ");

        DoorMachine machine = new DoorMachine();

        Console.WriteLine("State awal: Pintu terkunci");
        machine.activateTrigger(DoorMachine.Trigger.KunciPintu);
        Console.WriteLine("State setelah mengunci trigger buka pintu, maka");
        machine.activateTrigger(DoorMachine.Trigger.BukaPintu);  
        Console.WriteLine("State menengah: Pintu Terbuka");
        machine.activateTrigger(DoorMachine.Trigger.BukaPintu);
        Console.WriteLine("State setelah membuka trigger mengunci, maka");
        machine.activateTrigger(DoorMachine.Trigger.KunciPintu);
        Console.WriteLine("State terakhir: pintu terkunci kembali");
        machine.activateTrigger(DoorMachine.Trigger.KunciPintu);
    }
}