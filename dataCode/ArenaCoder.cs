using Godot;
using System.Collections.Generic;
using System;
using System.Linq;

public class ArenaCoder : Node2D {
	//Classes:
	public class Tile{
		public byte x{get;set;}
		public byte y{get;set;}
		public short degrees{get;set;}
		public string type{get;set;}
		public byte id{get;set;}
		public Tile(byte x, byte y, short degrees, string type, byte id){
			this.x = x;
			this.y = y;
			this.degrees = degrees;
			this.type = type;
			this.id = id;
		}
	}

	public static string reverse(string s){
		if (s == null) return null;
		char[] charArray = s.ToCharArray();
		int len = s.Length - 1;
		for (int i = 0; i < len; i++, len--){
			charArray[i] ^= charArray[len];
			charArray[len] ^= charArray[i];
			charArray[i] ^= charArray[len];
		}
		return new string(charArray);
	}

	public string[] filter(string native_code){
		string[] final_code = (native_code.Replace("\n", "").Replace("\r", "").Replace("\b", "").Replace("\t", "")).Split(new char[] { ',' });
		GD.Print($"Codes array: {string.Join(", ", final_code)}");
		return final_code;
	}

	public int getIndex(string c) {
		Dictionary<string, int> BaseDecoder = this.tileDictionary();
		int result = 777;
		try{
			result = (byte)BaseDecoder[c];
		}catch{
			result = 0;
		}
		return result;
	}

	public string getStraightName(int index){
		Dictionary<int, string> BaseDecoder = this.straightTileDictionary();
		string result = "Penis";
		try{
			result = BaseDecoder[index];
		}catch{
			result = "Não encontrado";
		}
		return result;
	}

	public string getCurvedName(int index){
		Dictionary<int, string> BaseDecoder = this.curvedTileDictionary();
		string result = "sim!";
		try{
			result = BaseDecoder[index];
		}catch{
			result = "Não encontrado";
		}
		return result;
	}

	public string GetStringByIndex(int id) {
		Dictionary<int, string> BaseDecoder = this.tileReverseDictionary();
		string result = "cleiton strings";
		try{
			result = BaseDecoder[id];
		}catch{
			result = "0";
		}
		return result;
	}

	public Tile decode(string code){
		byte pos_x = 0;
		byte pos_y = 0;
		short direction = 0;
		string compl0 = "r";
		byte compl1 = 0;
		try{
			pos_x = byte.Parse(reverse(code.Substring(0, 2)));
			pos_y = byte.Parse(reverse(code.Substring(2, 2)));
			direction = short.Parse(code.Substring(6, 3));
			compl0 = code.Substring(4, 1);
			compl1 = (byte)getIndex(code.Substring(5, 1));
		}catch{
			GD.Print($"The code: {code} is not a tile code! Returning emply tile");
			return new Tile(0, 0, 0, "r", 71);
		}

		direction = (direction != 0 && direction != 90 && direction != 180 && direction != 270) ? (byte)0 : direction;
		//GD.Print($"For code: '{code}' -> position: <{pos_x}, {pos_y}> | direction: {direction} | complement: <{compl0}, {compl1}>");
		return new Tile(pos_x, pos_y, direction, compl0, compl1);
	}

	public string encode(Tile CurrentTile){
		return $"{CurrentTile.x}0{CurrentTile.y}0{CurrentTile.type}{GetStringByIndex(CurrentTile.id)}{(CurrentTile.degrees).ToString("000")}";
	}

	private Dictionary<int, string> tileReverseDictionary(){
		return new Dictionary<int, string>{
			{0, "0"},
			{1, "1"},
			{2, "2"},
			{3, "3"},
			{4, "4"},
			{5, "5"},
			{6, "6"},
			{7, "7"},
			{8, "8"},
			{9, "9"},
			{10, "a"},
			{11, "b"},
			{12, "c"},
			{13, "d"},
			{14, "e"},
			{15, "f"},
			{16, "g"},
			{17, "h"},
			{18, "i"},
			{19, "j"},
			{20, "k"},
			{21, "l"},
			{22, "m"},
			{23, "n"},
			{24, "o"},
			{25, "p"},
			{26, "q"},
			{27, "r"},
			{28, "s"},
			{29, "t"},
			{30, "u"},
			{31, "v"},
			{32, "w"},
			{33, "x"},
			{34, "y"},
			{35, "z"},
			{36, "A"},
			{37, "B"},
			{38, "C"},
			{39, "D"},
			{40, "E"},
			{41, "F"},
			{42, "G"},
			{43, "H"},
			{44, "I"},
			{45, "J"},
			{46, "K"},
			{47, "L"},
			{48, "M"},
			{49, "N"},
			{50, "O"},
			{51, "P"},
			{52, "Q"},
			{53, "R"},
			{54, "S"},
			{55, "T"},
			{56, "U"},
			{57, "V"},
			{58, "W"},
			{59, "X"},
			{60, "Y"},
			{61, "Z"},
			{62, "+"},
			{63, "/"},
			{64, "="},
			{65, "<"},
			{66, ">"},
			{67, "{"},
			{68, "}"},
			{69, "["},
			{70, "]"},
			{71, "("},
			{72, ")"},
			{73, "?"},
			{74, "&"},
			{75, "$"},
			{76, "^"},
			{77, "-"},
			{78, "_"},
			{79, "@"},
			{80, "Á"},
			{81, "É"},
			{82, "Í"},
			{83, "Ó"}
		};
	}

	private Dictionary<string, int> tileDictionary(){
		return new Dictionary<string, int>{
			{"0", 0},
			{"1", 1},
			{"2", 2},
			{"3", 3},
			{"4", 4},
			{"5", 5},
			{"6", 6},
			{"7", 7},
			{"8", 8},
			{"9", 9},
			{"a", 10},
			{"b", 11},
			{"c", 12},
			{"d", 13},
			{"e", 14},
			{"f", 15},
			{"g", 16},
			{"h", 17},
			{"i", 18},
			{"j", 19},
			{"k", 20},
			{"l", 21},
			{"m", 22},
			{"n", 23},
			{"o", 24},
			{"p", 25},
			{"q", 26},
			{"r", 27},
			{"s", 28},
			{"t", 29},
			{"u", 30},
			{"v", 31},
			{"w", 32},
			{"x", 33},
			{"y", 34},
			{"z", 35},
			{"A", 36},
			{"B", 37},
			{"C", 38},
			{"D", 39},
			{"E", 40},
			{"F", 41},
			{"G", 42},
			{"H", 43},
			{"I", 44},
			{"J", 45},
			{"K", 46},
			{"L", 47},
			{"M", 48},
			{"N", 49},
			{"O", 50},
			{"P", 51},
			{"Q", 52},
			{"R", 53},
			{"S", 54},
			{"T", 55},
			{"U", 56},
			{"V", 57},
			{"W", 58},
			{"X", 59},
			{"Y", 60},
			{"Z", 61},
			{"+", 62},
			{"/", 63},
			{"=", 64},
			{"<", 65},
			{">", 66},
			{"{", 67},
			{"}", 68},
			{"[", 69},
			{"]", 70},
			{"(", 71},
			{")", 72},
			{"?", 73},
			{"&", 74},
			{"$", 75},
			{"^", 76},
			{"-", 77},
			{"_", 78},
			{"@", 79},
			{"Á", 80},
			{"É", 81},
			{"Í", 82},
			{"Ó", 83}
		};
	}

	public Dictionary<int, string> straightTileDictionary(){
		return new Dictionary<int, string>{
			{993, "<b>======== Especiais ========</b>"},
			{75, "Ladrilho de início"},
			{77, "Ladrilho de início com paredes"},
			{76, "Ladrilho de início sem linha"},
			{78, "Ladrilho final"},
			{80, "Ladrilho final com paredes"},
			{79, "Ladrilho final sem linha"},
			{71, "Ladrilho Vazio"},
			{73, "Terceira Sala"},
			{999, "<b>======== Sem pontuação ========</b>"},
			{72, "Entrada sala de resgate"},
			{82, "Escadaria"},
			{0, "Linha"},
			{51, "Linha com V"},
			{56, "Meia Lua"},
			{3, "Zigue-Zague"},
			{5, "Zigue-Zague 90°"},
			{68, "Zigue-Zague 90° Unilateral"},
			{57, "Zigue-Zague Suave"},
			{60, "Zigue-Zague Suave Unilateral"},
			{63, "Zigue-Zague Unilateral"},
			{998, "<b>======== Com pontuação ========</b>"},
			{33, "2 Gaps"},
			{18, "4 Retornos"},
			{6, "Encruzilhada C"},
			{50, "Encruzilhada C com Gap"},
			{24, "Encruzilhada Reta"},
			{25, "Encruzilhada T Reta"},
			{74, "Gangorra"},
			{1, "Gap"},
			{32, "Gap e Redutor"},
			{35, "Gap e Redutor Inclinado"},
			{4, "Obstáculo"},
			{7, "Obstáculo Sem-Linhas"},
			{23, "Portal"},
			{2, "Redutor"},
			{34, "Redutor Inclinado"},
			{22, "Redutores"},
			{36, "Redutores Inclinados"},
			{81, "Rotatória"},
			{37, "Zigue-Zague com Redutor"},
			{997, "<b>======== Elevadas sem pontuação ========</b>"},
			{52, "Linha com V Elevado"},
			{53, "Linha com V Elevado com Linha Inferior"},
			{26, "Linha Elevada com Linha Inferior"},
			{8, "Rampa"},
			{12, "Reta Elevada"},
			{17, "Zigue-Zague 90° Elevado"},
			{31, "Zigue-Zague 90° Elevado com Linha Inferior"},
			{69, "Zigue-Zague 90° Unilateral Elevado "},
			{70, "Zigue-Zague 90° Unilateral Elevado com Linha Inferior"},
			{16, "Zigue-Zague Elevado"},
			{30, "Zigue-Zague Elevado com Linha Inferior"},
			{58, "Zigue-Zague Suave Elevado"},
			{59, "Zigue-Zague Suave Elevado com Linha Inferior"},
			{61, "Zigue-Zague Suave Unilateral Elevado"},
			{62, "Zigue-Zague Suave Unilateral Elevado com Linha Inferior"},
			{64, "Zigue-Zague Unilateral Elevado"},
			{65, "Zigue-Zague Unilateral Elevado com Linha Inferior"},
			{996, "<b>======== Elevadas com pontuação ========</b>"},
			{39, "2 Gaps Elevados"},
			{38, "2 Gaps Elevados com Linha Inferior"},
			{45, "Gap e Redutor Elevado"},
			{44, "Gap e Redutor Elevado com Linha Inferior"},
			{43, "Gap e Redutor Inclinado Elevado"},
			{42, "Gap e Redutor Inclinado Elevado com Linha Inferior"},
			{13, "Gap Elevado"},
			{27, "Gap Elevado com Linha Inferior"},
			{9, "Rampa com Gap"},
			{10, "Rampa com Redutor"},
			{11, "Rampa com Redutores"},
			{14, "Redutor Elevado"},
			{28, "Redutor Elevado com Linha Inferior"},
			{41, "Redutor Inclinado Elevado"},
			{40, "Redutor Inclinado Elevado com Linha Inferior"},
			{15, "Redutores Elevados"},
			{29, "Redutores Elevados com Linha Inferior"},
			{47, "Redutores Inclinados Elevados"},
			{46, "Redutores Inclinados Elevados com Linha Inferior"},
			{49, "Zigue-Zague com Redutor Elevado"},
			{48, "Zigue-Zague com Redutor Elevado com Linha Inferior"},
			{995, "<b>======== Peças de labirinto ========</b>"},
			{21, "3 Paredes"},
			{20, "Parede"},
			{19, "Paredes Laterais"},
			{994, "<b>======== Conjunto de peças ========</b>"},
			{54, "Conjunto Bilateral"},
			{55, "Conjunto Bilateral Elevado"},
			{66, "Conjunto Unilateral"},
			{67, "Conjunto Unilateral Elevado"
			}
		};
	}

	public Dictionary<int, string> curvedTileDictionary(){
		return new Dictionary<int, string>{
			{993, "<b>======== Especiais ========</b>"},
			{22, "Ladrilho Vazio"},
			{999, "<b>======== Sem pontuação ========</b>"},
			{1, "Curva 90°"},
			{3, "Curva Complexa"},
			{15, "Curva Degrau"},
			{17, "Curva Degrau Suave"},
			{24, "Curva Diagonal"},
			{0, "Curva Suave"},
			{30, "Dupla de Curvas Degrau"},
			{29, "Dupla de Curvas Degrau Suave"},
			{31, "Dupla de Curvas Diagonal"},
			{32, "Dupla de Curvas Suave"},
			{25, "Rotatória Aberta"},
			{998, "<b>======== Com pontuação ========</b>"},
			{4, "Encruzilhada C"},
			{14, "Encruzilhada C com gap"},
			{2, "Encruzilhada Circular"},
			{7, "Encruzilhada com Verde"},
			{8, "Encruzilhada Dupla"},
			{9, "Encruzilhada Dupla Cruzada"},
			{5, "Encruzilhada T"},
			{6, "Encruzilhada T Dupla"},
			{10, "Encruzilhada Tripla"},
			{23, "Obstáculo"},
			{27, "Rotatória Com Curva 90°"},
			{26, "Rotatória Com Degraus"},
			{28, "Rotatória Externa"},
			{997, "<b>======== Elevadas sem pontuação ========</b>"},
			{12, "Curva 90° Elevada"},
			{16, "Curva Degrau Elevada"},
			{18, "Curva Degrau Suave Elevada"},
			{13, "Curva Suave Elevada"},
			{995, "<b>======== Peças de labirinto ========</b>"},
			{11, "Parede Curvada"},
			{994, "<b>======== Conjunto de peças ========</b>"},
			{21, "Conjunto Encruzilhadas Simples"},
			{19, "Conjunto Simples"},
			{20, "Conjunto Simples Elevado"
			}
		};
	}
	//

	[Export] public string manual_arena = "";

	private PackedScene TileBase_scene = (PackedScene)ResourceLoader.Load("res://dataScenes/TileBase.tscn");
	private PackedScene UnderLine_scene = (PackedScene)ResourceLoader.Load("res://dataScenes/UnderLine_tile.tscn");
	private PackedScene Notification_scene = (PackedScene)ResourceLoader.Load("res://dataScenes/Notification.tscn");

	//Base textures
	private Texture BaseWhite_texture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Complementares/Fundo_branco.png");
	
	//Geral
	string lastType = "r";
	Tile LocalClipboard = new Tile(0, 0, 0, "null", 0);
	//bool NoisedTiles = false;
	Tile CustomDat = new Tile(0, 0, 0, "null", 0);
	Vector2 OffsetRescue =  new Vector2(0, 256);
	List<byte> endTiles = new List<byte>();
	List<byte> straightList = new List<byte>();
	List<byte> curvedList = new List<byte>();
	byte maxValueStraight = 1;
	byte maxValueCurved = 1;
	//

	//Pre-define variables for utils
	string[] UnderLineTiles = new string[]{"r26", "r27", "r28", "r29", "r30", "r31", "r38", "r40", "r42", "r44", "r46", "r48", "r53", "r59", "r62", "r65", "r70"};
	string[] TopTiles = new string[]{"r8", "r9", "r10", "r11", "r12", "r13", "r14", "r15", "r16", "r17", "r39", "r41", "r43", "r45", "r49", "r52", "r55", "r58", "r61", "r64", "r67", "r69", "c12", "c13", "16", "c18", "c20", "r26", "r27", "r28", "r29", "r30", "r31", "r38", "r40", "r42", "r44", "r46", "r48", "r53", "r59", "r62", "r65", "r70"};
	string[] ConjTiles = new string[]{"r54", "r55", "r66", "r67", "r19", "r20", "r21", "c19", "c20", "c21"};
	//

	//Arena settings:
	bool BoolEndCd = false; //FINALIZAR ROTINA NO FIM DO CÓDIGO
	bool BoolNoPos = false; //ALTERAR POSIÇÃO EM ROTINA
	bool BoolPrgso = false; //FALHA DE PROGRESSO
	bool BoolShowM = false; //EXIBIR MARCADORES DE ARENA
	bool BoolSlnha = false; //NECESSIDADE DE SEGUIR LINHA
	bool BoolTSala = false; //TIPO TRIANGULO: QUALQUER NUMERO DIFERENTE DE 2 É TRIANGULO NIVEL 1
	bool BoolTpFim = false; //FINALIZAR ROTINA NO FIM DO TEMPO
	string Descricao = "Arena modificada pelo editor de arenas externo do sBotics :)"; //DESCRIÇÃO DA ARENA
	string[] HoraDoDia = {"12","00"}; //HORARIO DA ARENA
	//string[] MarcadorF; //MARCADOR FALHAS
	//string[] MarcadorP; //MARCADOR NORMAL
	bool MoveObsto = false; //PERMISSÃO DE MOVER OBSTÁCULO SEM FALHA
	short ObstacTmp = 30; //TEMPO DE OBSTÁCULO EM SEGUNDOS
	bool PontoDist = false; //PONTUAÇÃO CONSIDERA DISTÂNCIA
	short ResgtePos = 1; //ÁREA DE RESGATE: 0 = SEM, 1 = ALEATORIO, 2 FRENTE, 3 = FRONTAL DIREITA, 4 = DIREITA
	string RobosPerm = "111111"; //PERMISSÕES DE USO DO ROBO NA ARENA, SEGUINDO A ORDEM: Robo1, Robo2, Robo3, Robo4, Robo5, RoboCustomizado
	short SaveMrcds = 0; //NUMERO DE MARCADORES
	short TempoMxmo = 3; // TEMPO MAXIMO:0 = 1m, 1 = 2m, 3 = 5m, 4 = 8m, 5 = 10m, 6 = 1440m ("SEM TEMPO LIMITE")
	bool VitmaPnts = false; //PONTUAÇÃO PONDERADA
	//string[] VelaAcesa; //POSIÇÃO OBJETO VELA ACESA
	//string[] VelaApgda; //POSIÇÃO OBJETO VELA APAGADA
	//string[] VitimOrta; //POSIÇÃO OBJETO VITIMA MORTA MANUAL
	//string[] VitimViva; //POSIÇÃO OBJETO VITIMA VIVA MANUAL
	short VtmsMrtas = 2; //QUANTIDADE VÍTIMAS MORTAS (< 10 && > 0)
	short VtmsVivas = 1; //QUANTIDADE VÍTIMAS VIVAS(< 10 && > 0)
	//string[] prfsrCubo; //POSIÇÃO OBJETO CUBO/PARALELEPIPEDO
	byte RescueTyp = 1;	/* INFO ABAIXO:
	0 = SEM RAMPA
	1 = RAMPA PADRÃO
	2 = RAMPA COM GAP
	3 = RAMPA COM REDUTOR
	4 = RAMPA COM REDUTORES
	5 = RAMPA COM DOIS GAPS
	6 = RAMPA COM GAP E REDUTOR */
	//

	//Arena code add
	string additional = "";
	//
	public void oldUpdateInfoMenu(){
		string output = "";
		output += $"BoolEndCd: {BoolEndCd.ToString()}\n";
		output += $"BoolNoPos: {BoolNoPos.ToString()}\n";
		output += $"BoolPrgso: {BoolPrgso.ToString()}\n";
		output += $"BoolShowM: {BoolShowM.ToString()}\n";
		output += $"BoolSlnha: {BoolSlnha.ToString()}\n";
		output += $"BoolTSala: {BoolTSala.ToString()}\n";
		output += $"BoolTpFim: {BoolTpFim.ToString()}\n";
		output += $"Descricao: {Descricao}\n";
		output += $"HoraDoDia: {HoraDoDia[0]}:{HoraDoDia[1]}\n";
		output += $"MoveObsto: {MoveObsto.ToString()}\n";
		output += $"ObstacTmp: {ObstacTmp}\n";
		output += $"PontoDist: {PontoDist.ToString()}\n";
		output += $"ResgtePos: {ResgtePos}\n";
		output += $"RobosPerm: {RobosPerm}\n";
		output += $"SaveMrcds: {SaveMrcds}\n";
		output += $"TempoMxmo: {TempoMxmo}\n";
		output += $"VitmaPnts: {VitmaPnts}\n";
		output += $"VtmsMrtas: {VtmsMrtas}\n";
		output += $"VtmsVivas: {VtmsVivas}\n";
		output += $"RescueTyp: {RescueTyp}\n";
		GetParent().GetNode("ViewMain").GetNode("Menu").GetNode<Label>("Infos").Text = output;
	}

	public Vector2 getTilePos(Vector2 TileVector){
		TileVector.x = (byte)((TileVector.x > 9) ? 9 : TileVector.x);
		TileVector.y = (byte)((TileVector.y > 9) ? 9 : TileVector.y);
		TileVector.x = (byte)((TileVector.x < 0) ? 0 : TileVector.x);
		TileVector.y = (byte)((TileVector.y < 0) ? 0 : TileVector.y);
		return new Vector2( (short)(448 + (TileVector.x * 256)), (short)(632 - (TileVector.y * 256)));
	}

	public void reserve(string tileconfig){
		additional += $",{tileconfig}";
	}

	private void resetArena(){//reset all default
		CustomDat = new Tile(0, 0, 0, "null", 0);
		BoolEndCd = false;
		BoolNoPos = false;
		BoolPrgso = false;
		BoolShowM = true;
		BoolSlnha = false;
		BoolTSala = false;
		BoolTpFim = false;
		Descricao = "Arena modificada pelo editor de arenas externo do sBotics :)";
		HoraDoDia = new string[]{"12","00"};
		//string[] MarcadorF;
		//string[] MarcadorP;
		MoveObsto = false;
		ObstacTmp = 30;
		PontoDist = false;
		ResgtePos = 1;
		RobosPerm = "111111";
		SaveMrcds = 2;
		TempoMxmo = 3;
		VitmaPnts = false;
		//string[] VelaAcesa;
		//string[] VelaApgda;
		//string[] VitimOrta;
		//string[] VitimViva;
		VtmsMrtas = 2;
		VtmsVivas = 2;
		//string[] prfsrCubo;
		RescueTyp = 1;
		additional = "";
		foreach(Sprite child in this.GetChildren()){
			removeTile(child);
		}
	}

	void PopNotification(string LabelText, Color ColorText){
		Label Notification_instance = (Label)Notification_scene.Instance();
		Notification_instance.Text = LabelText;
		Notification_instance.Set("custom_colors/font_color", ColorText);
		foreach(Label child in GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<Control>("Temp").GetChildren()){
			child.CallDeferred("free");
		}
		GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<Control>("Temp").CallDeferred("add_child", Notification_instance);
	}

	public bool checkCustomTile(Tile cTile){//VERIFICA SE LADRILHO É FINAL
		if((CustomDat.type != "null")){
			if(($"{cTile.type}{cTile.id}" == "r73") || ((cTile.type == "r") && (endTiles.IndexOf((byte)cTile.id) != -1)) ){
				return true;
			}
		}
		return false;
	}

	public void tileEvent(Vector2 TileLocation, byte Event){
		Sprite TileChild = (Sprite)GetNodeOrNull<Sprite>($"{TileLocation.x}0{TileLocation.y}0");
		Tile CurrentTile = new Tile(0, 0, 0, "null", 0);

		if(Event == 6){//ROTATE TILE
			if(TileChild != null){
				CurrentTile = decode((string)TileChild.Get("Info"));
				CurrentTile.degrees = (short)(((CurrentTile.degrees + 90) == 360) ? 0 : (CurrentTile.degrees + 90));
			}else{
				CurrentTile.type = lastType;
				CurrentTile.id = 0;
				CurrentTile.x = (byte)TileLocation.x;
				CurrentTile.y = (byte)TileLocation.y;
				CurrentTile.degrees = (short)(((CurrentTile.degrees + 90) == 360) ? 0 : (CurrentTile.degrees + 90));
			}
			PopNotification("Ladrilho rotacionado", new Color("#3ebc51"));

		}else if(Event == 5){//PASTE TILE
			CurrentTile = LocalClipboard;
			if(TileChild != null){
				if(checkCustomTile(decode((string)TileChild.Get("Info")))){
					removeTile(TileChild);
				}
			}else if(checkCustomTile(CurrentTile)){
				PopNotification("Ladrilho não permitido", new Color("#E62044"));
				return;
			}

			CurrentTile.x = (byte)TileLocation.x;
			CurrentTile.y = (byte)TileLocation.y;
			PopNotification("Ladrilho colado", new Color("#3ebc51"));

		}else if(Event == 4){//COPY TILE

			if(TileChild != null){
				LocalClipboard = decode((string)TileChild.Get("Info"));
				if(checkCustomTile(LocalClipboard)){
					PopNotification("Ladrilho não permitido", new Color("#E62044"));
					CurrentTile.type = lastType;
					CurrentTile.id = 0;
					CurrentTile.x = (byte)TileLocation.x;
					CurrentTile.y = (byte)TileLocation.y;
					LocalClipboard = CurrentTile;
					return;
				}
			}else{
				CurrentTile.type = lastType;
				CurrentTile.id = 0;
				CurrentTile.x = (byte)TileLocation.x;
				CurrentTile.y = (byte)TileLocation.y;
				LocalClipboard = CurrentTile;
			}
			PopNotification("Ladrilho copiado", new Color("#daa520"));

		}else if(TileChild != null){

			CurrentTile = decode((string)TileChild.Get("Info"));

			if(Event == 3){//DELETE
				removeTile(TileChild);
				PopNotification("Ladrilho deletado", new Color("#f2421b"));
				return;

			}else if(Event == 2){//CHANGE TYPE
				CurrentTile.type = (CurrentTile.type == "r") ? "c" : "r";
				lastType = CurrentTile.type;
				CurrentTile.id = 0;
				PopNotification("Tipo de ladrilho modificado", new Color("#07B0F2"));

			}else if(CurrentTile.type == "r"){//CHANGE TILE
				SaveTryR:
				byte CurrentIndex = (byte)straightList.IndexOf((byte)CurrentTile.id);
				try{
					CurrentTile.id = straightList[CurrentIndex-(-1*((Event*2)-1))];
					if(checkCustomTile(decode((string)TileChild.Get("Info")))){
						removeTile(TileChild);
					}else if(checkCustomTile(CurrentTile)){
						goto SaveTryR;
					}
				}catch{
					if(CurrentIndex <= 0){
						CurrentTile.id = straightList[maxValueStraight];
					}else if(CurrentIndex >= maxValueStraight){
						CurrentTile.id = straightList[0];
					}else{
						CurrentTile.id = 0;
					}
				}

				PopNotification("Ladrilho alterado", new Color("#1fe2f0"));

			}else if(CurrentTile.type == "c"){//CHANGE TILE
				byte CurrentIndex = (byte)curvedList.IndexOf((byte)CurrentTile.id);
				try{
					CurrentTile.id = curvedList[CurrentIndex-(-1*((Event*2)-1))];
				}catch{
					if(CurrentIndex <= 0){
						CurrentTile.id = curvedList[maxValueCurved];
					}else if(CurrentIndex >= maxValueCurved){
						CurrentTile.id = curvedList[0];
					}else{
						CurrentTile.id = 0;
					}
				}

				PopNotification("Ladrilho alterado", new Color("#1fe2f0"));

			}else{//ELSE ALL
				CurrentTile.type = lastType;
				CurrentTile.id = 0;
				CurrentTile.x = (byte)TileLocation.x;
				CurrentTile.y = (byte)TileLocation.y;
				PopNotification("Ladrilho alterado", new Color("#1fe2f0"));
			}
		}else{// ELSE ALL 	
			CurrentTile.type = lastType;
			CurrentTile.id = 0;
			CurrentTile.x = (byte)TileLocation.x;
			CurrentTile.y = (byte)TileLocation.y;
			PopNotification("Ladrilho alterado", new Color("#1fe2f0"));
		}
		if(filterFlags(CurrentTile)){
			loadFlags();
		}else{
			addTile(CurrentTile, true);
		}
	}

	public void updateInfoMenu(){
		GetNode<Node2D>("/root/Main/Arena/ViewMain").Call("updateTileInfo");

		GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<Label>("SunInfoLabel").Text = $"{HoraDoDia[0]}:{HoraDoDia[1]}";
		if((short.Parse(HoraDoDia[0]) > 18) || (short.Parse(HoraDoDia[0]) <= 6)){
			GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<TextureRect>("TimeImage").Texture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Outros/moon_phase_96px.png");
			GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<Label>("SunInfoLabel").Set("custom_colors/font_color", new Color("#575580"));
		
		}else if((short.Parse(HoraDoDia[0]) > 12) && (short.Parse(HoraDoDia[0]) <= 18)){
			GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<TextureRect>("TimeImage").Texture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Outros/sunset_96px.png");
			GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<Label>("SunInfoLabel").Set("custom_colors/font_color", new Color("#3686a0"));
		
		}else{
			GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<TextureRect>("TimeImage").Texture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Outros/summer_96px.png");
			GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<Label>("SunInfoLabel").Set("custom_colors/font_color", new Color("#ffd700"));
		}
	}

	public bool filterFlags(Tile ctile){//DETECTA E SETA A SALA 3 E FINAL DE PISTA
		if((CustomDat.type == "null")){
			if((ctile.type == "r") && (ctile.id == 73)){//REGATE
				CustomDat = ctile;
				GD.Print("Added rescue");
				return true;
			}else if((ctile.type == "r") && (endTiles.IndexOf((byte)ctile.id) != -1)){//FINAL
				CustomDat = ctile;
				GD.Print("Added end round");
				return true;
			}
		}
		return false;
	}

	public void loadFlags(){
		if(CustomDat.type != "null"){
			addTile(CustomDat, true);
		}
	}

	public Texture loadTextureTile(string type, short id){
		Texture CurrentTexture = BaseWhite_texture;
		try{
			if(type.ToLower() == "r"){
				if($"{type}{id}" == "r73"){
					CurrentTexture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Ladrilhos/Retas/{id}_{RescueTyp}.png");
				}else{
					CurrentTexture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Ladrilhos/Retas/{id}.png");
				}
			}else if(type.ToLower() == "c"){
				CurrentTexture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Ladrilhos/Curvas/{id}.png");
			}
		}catch{
			GD.Print($"Error on import tile with type {type} and id: {id}");
			CurrentTexture = BaseWhite_texture;
		}
		return CurrentTexture;
	}

	public void removeTile(Sprite Child){
		Child.Set("visible", false);
		Tile CurrentTile = decode((string)Child.Get("Info"));
		if(checkCustomTile(CurrentTile)){
			CustomDat = new Tile(0, 0, 0, "null", 0);
			GD.Print("Removed custom tile");
		}
		Child.CallDeferred("free");
	}

	public void addTile(Tile CurrentTile, bool UpdateInfo){
		if(CurrentTile.type == "null"){return;}
		Vector2 TilePosition = getTilePos(new Vector2(CurrentTile.x, CurrentTile.y));
		string TileBaseComparer = $"{CurrentTile.type}{CurrentTile.id}";
		bool ComparePosition(string CurrentName){
			byte pos_x = byte.Parse(reverse(CurrentName.Substring(0, 2)));
			byte pos_y = byte.Parse(reverse(CurrentName.Substring(2, 2)));
			return ((pos_x == CurrentTile.x) && (pos_y == CurrentTile.y));
		}
		foreach(Sprite child in this.GetChildren()){
			try{
				if(ComparePosition(child.Name)){
					removeTile(child);
					break;
				}
			}catch{
				continue;
			}
		}
		Sprite CurrentChild = (Sprite)TileBase_scene.Instance();
		CurrentChild.Texture = loadTextureTile(CurrentTile.type, CurrentTile.id);
		CurrentChild.Position = TilePosition;
		CurrentChild.RotationDegrees = CurrentTile.degrees;
		CurrentChild.Name = $"{(string)encode(CurrentTile).Substring(0, 4)}";
		CurrentChild.Set("Info",  (string)encode(CurrentTile));
		CurrentChild.Set("UpdateInfo",  UpdateInfo);

		//Visual text set #########################################################################################################################################################################################################################################################
		//Set name
		if(CurrentTile.type == "c"){
			CurrentChild.Set("Name",  $"{CurrentTile.id}| {getCurvedName(CurrentTile.id)}");
		}else if(CurrentTile.type == "r"){
			CurrentChild.Set("Name",  $"{CurrentTile.id}| {getStraightName(CurrentTile.id)}");
		}else{
			CurrentChild.Set("Name",  "-");
		}

		//Set color
		if((TopTiles.Contains(TileBaseComparer)) && (ConjTiles.Contains(TileBaseComparer))){//METADINHA
			CurrentChild.Set("Color",  new Color((0.450980f + 1f) / 2f, (0.388235f + 0.247059f) / 2f, (1f + 0.286275f) / 2f));
		
		}else if(TopTiles.Contains(TileBaseComparer)){//ELEVADO
			CurrentChild.Set("Color", new Color(0.450980f, 0.388235f, 1f));
		
		}else if(ConjTiles.Contains(TileBaseComparer)){//CONJUNTO
			CurrentChild.Set("Color", new Color(1f, 0.247059f, 0.286275f));
		
		}else if(TileBaseComparer == "r74"){//GANGORRA
			CurrentChild.Set("Color", new Color(0.490196f, 1f, 0.509804f));
		
		}else{//NENHUM
			CurrentChild.Set("Color", new Color(1f, 1f, 1f));
		}
		//#########################################################################################################################################################################################################################################################################
		
		//Case underline tile:Child
		if(UnderLineTiles.Contains(TileBaseComparer)){
			GD.Print($"Underline tile: {TileBaseComparer}");
			Sprite Filter_child = new Sprite();
			Filter_child.Texture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Complementares/Filtro_Azul_Linha.png");
			Filter_child.ZIndex = 1;
			Filter_child.Name = "Filter";
			CurrentChild.CallDeferred("add_child", Filter_child);
			Area2D CurrentUnderLine = (Area2D)UnderLine_scene.Instance();
			CurrentUnderLine.GetNode<Sprite>("UnderLineSprite").Texture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Ladrilhos/Retas/{CurrentTile.id}_.png");
			CurrentChild.CallDeferred("add_child", CurrentUnderLine);
		}
		GD.Print($"addTile -> position: <{CurrentTile.x}, {CurrentTile.y}> | direction: {CurrentTile.degrees} | complement: <{CurrentTile.type}, {CurrentTile.id}>");
		CallDeferred("add_child", CurrentChild);
	}

	public string decodeArena(){
		string Output = "";
		foreach(Sprite child in this.GetChildren()){
			Output += $"{(string)child.Get("Info")},";
		}
		Output += $"Descricao: {Descricao}";
		if(BoolEndCd != false){
			Output += $",BoolEndCd: {BoolEndCd.ToString()}";
		}
		if(BoolNoPos != false){
			Output += $",BoolNoPos: {BoolNoPos.ToString()}";
		}
		if(BoolPrgso != false){
			Output += $",BoolPrgso: {BoolPrgso.ToString()}";
		}
		if(BoolShowM != true){
			Output += $",BoolShowM: {BoolShowM.ToString()}";
		}
		if(BoolSlnha != false){
			Output += $",BoolSlnha: {BoolSlnha.ToString()}";
		}
		if(BoolTSala != false){
			Output += $",BoolTSala: {BoolTSala.ToString()}";
		}
		if(BoolTpFim != false){
			Output += $",BoolTpFim: {BoolTpFim.ToString()}";
		}
		if((HoraDoDia[0] != "12") && (HoraDoDia[1] != "00")){
			Output += $",HoraDoDia: {HoraDoDia[0]}:{HoraDoDia[1]}";
		}
		if(MoveObsto != false){
			Output += $",MoveObsto: {MoveObsto.ToString()}";
		}
		if(ObstacTmp != 30){
			Output += $",ObstacTmp: {ObstacTmp.ToString()}";
		}
		if(PontoDist != false){
			Output += $",PontoDist: {PontoDist.ToString()}";
		}
		if(ResgtePos != 1){
			Output += $",ResgtePos: {ResgtePos.ToString()}";
		}
		if(RobosPerm != "111111"){
			Output += $",RobosPerm: {RobosPerm}";
		}
		if(SaveMrcds != 2){
			Output += $",SaveMrcds: {SaveMrcds.ToString()}";
		}
		if(TempoMxmo != 3){
			Output += $",TempoMxmo: {TempoMxmo.ToString()}";
		}
		if(VitmaPnts != false){
			Output += $",VitmaPnts: {VitmaPnts.ToString()}";
		}
		if(VtmsMrtas != 2){
			Output += $",VtmsMrtas: {VtmsMrtas.ToString()}";
		}
		if(VtmsVivas != 2){
			Output += $",VtmsVivas: {VtmsVivas.ToString()}";
		}
		if(RescueTyp != 1){
			Output += $",{RescueTyp}";
		}
		PopNotification("Código de arena copiado", new Color(0, 0.8f, 0));
		return Output+additional;
	}

	public void regenerateArena(string arena_code){
		//System.Threading.Tasks.Task CurrentArenaThread = System.Threading.Tasks.Task.Factory.StartNew(() => {
			resetArena();

			string[] final_code = filter(arena_code);
			Tile CurrentTile;
			PopNotification("", new Color("#ffffff"));
			//GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<ProgressBar>("ProgressBar").Visible = true;
			//GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<ProgressBar>("ProgressBar").Value = 0;
			//float MedCount = 100f / (float)final_code.Count();
			//GD.Print($"MedCount: {MedCount}");
			foreach (string code in final_code){
				//GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<ProgressBar>("ProgressBar").Value += MedCount;
				if(code.Length > 9){
					if((code.Substring(0, 10) != "Descricao:")){
						code.Replace(" ", "");
					}else{
						Descricao = code.Substring(11);
						continue;
					}
				}else{code.Replace(" ", "");}
				if(code.Length == 9){//Normal tile
					CurrentTile = decode(code);
					if(filterFlags(CurrentTile)){continue;}
					addTile(CurrentTile, false);

				}else if(code.Length == 1){//Probaly config code
					try{
						RescueTyp = byte.Parse(code);
					}catch{
						GD.Print($"Cant Parse {code} to byte!");
					}

				}else if(code.Length > 9){//Probaly config code
					try{
						switch (code.Substring(0, 10)){
							case "BoolEndCd:":
								if(code.Substring(10) == "false"){
									BoolEndCd = false;
									break;
								}
								BoolEndCd = true;
								break;
							case "BoolNoPos:":
								if(code.Substring(10) == "false"){
									BoolNoPos = false;
									break;
								}
								BoolNoPos = true;
								break;
							case "BoolPrgso:":
								if(code.Substring(10) == "false"){
									BoolPrgso = false;
									break;
								}
								BoolPrgso = true;
								break;
							case "BoolShowM:":
								if(code.Substring(10) == "false"){
									BoolShowM = false;
									break;
								}
								BoolShowM = true;
								break;
							case "BoolSlnha:":
								if(code.Substring(10) == "false"){
									BoolSlnha = false;
									break;
								}
								BoolSlnha = true;
								break;
							case "BoolTSala:":
								BoolTSala = code.Substring(10) == "2";
								break;
							case "BoolTpFim:":
								if(code.Substring(10) == "false"){
									BoolTpFim = false;
									break;
								}
								BoolTpFim = true;
								break;
							case "HoraDoDia:":
								string hcode = code.Replace(" ", "");
								string[] HorarioArray = hcode.Substring(10).Split(':');
								if (hcode.Substring(10) == HorarioArray[0]){
									HoraDoDia = new string[]{"12", "00"};
									break;
								}
								HorarioArray[0] = short.Parse(HorarioArray[0]).ToString("00");
								HorarioArray[1] = short.Parse(HorarioArray[1]).ToString("00");
								HoraDoDia = HorarioArray;
								break;
							case "Imagem001:":
								reserve(code);
								break;
							case "Imagem021:":
								reserve(code);
								break;
							case "Imagem022:":
								reserve(code);
								break;
							case "Imagem023:":
								reserve(code);
								break;
							case "Imagem024:":
								reserve(code);
								break;
							case "Imagem031:":
								reserve(code);
								break;
							case "Imagem032:":
								reserve(code);
								break;
							case "Imagem101:":
								reserve(code);
								break;
							case "Imagem102:":
								reserve(code);
								break;
							case "Imagem103:":
								reserve(code);
								break;
							case "Imagem104:":
								reserve(code);
								break;
							case "Imagem105:":
								reserve(code);
								break;
							case "Imagem106:":
								reserve(code);
								break;
							case "Imagem107:":
								reserve(code);
								break;
							case "Imagem108:":
								reserve(code);
								break;
							case "Imagem109:":
								reserve(code);
								break;
							case "Imagem110:":
								reserve(code);
								break;;
							case "Imagem111:":
								reserve(code);
								break;
							case "Imagem112:":
								reserve(code);
								break;
							case "Imagem113:":
								reserve(code);
								break;
							case "Imagem114:":
								reserve(code);
								break;
							case "Imagem115:":
								reserve(code);
								break;
							case "Imagem116:":
								reserve(code);
								break;
							case "Imagem117:":
								reserve(code);
								break;
							case "Imagem118:":
								reserve(code);
								break;
			
							case "MarcadorF:":
								reserve(code);
								break;;
							case "MarcadorP:":
								reserve(code);
								break;
							case "MoveObsto:":
								MoveObsto = !(code.Substring(10) == "false");
								break;
							case "ObstacTmp:":
								ObstacTmp = short.Parse(code.Substring(10));
								break;
							case "PontoDist:":
								PontoDist = !(code.Substring(10) == "false");
								break;
							case "ResgtePos:":
								ResgtePos = short.Parse(code.Substring(10));
								break;
							case "RobosPerm:":
								if (code.Substring(10).Length == 6 && code.Substring(10) != "000000"){
									RobosPerm = code.Substring(10);
									break;
								}
								RobosPerm = "111111";
								break;
							case "SaveMrcds:":
								SaveMrcds = short.Parse(code.Substring(10));
								break;
							case "TempoMxmo:":
							  switch (int.Parse(code.Substring(10))){
								case 0:
								  TempoMxmo = 0;
								  break;
								case 1:
								  TempoMxmo = 1;
								  break;
								case 2:
								  TempoMxmo = 2;
								  break;
								case 4:
								  TempoMxmo = 4;
								  break;
								case 5:
								  TempoMxmo = 5;
								  break;
								case 6:
								  TempoMxmo = 6;
								  break;
								default:
								  TempoMxmo = 3;
								  break;
							  }
							  break;
							case "VelaAcesa:":
								reserve(code);
								break;
							case "VelaApgda:":
								reserve(code);
								break;
							case "VitimOrta:":
								reserve(code);
								break;
							case "VitimViva:":
								reserve(code);
								break;
							case "VitmaPnts:":
								VitmaPnts = !(code.Substring(10) == "false");
								break;
							case "VtmsMrtas:":
								VtmsMrtas = short.Parse(code.Substring(10));
								if (VtmsMrtas > 10 || VtmsMrtas < 0){
									VtmsMrtas = 0;
								}
							  break;
							case "VtmsVivas:":
								VtmsVivas = short.Parse(code.Substring(10));
								if (VtmsVivas > 10 || VtmsVivas < 0){
									VtmsVivas = 0;
								}
							  break;
							case "prfsrCubo:":
								reserve(code);
								break;
							default:
								GD.Print($"No values for {code}");
								//return false;
								break;
					  	}
					}catch (Exception ex){
						GD.Print($"Error on load switch code: {code}, with exception: {ex.Message}");
						PopNotification("Não foi possível importar a arena", new Color(0.8f, 0, 0));
					}
				}
			}
			//GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<ProgressBar>("ProgressBar").Visible = false;
			//GetNode<Node2D>("/root/Main/Arena/ViewMain").GetNode<Control>("Menu").GetNode<ProgressBar>("ProgressBar").Value = 0;
			loadFlags();
			updateInfoMenu();
			PopNotification("Arena importada com sucesso", new Color(0, 0.8f, 0));
		//});
	}

	private void preLoad(){
		foreach(int CurrentValue in straightTileDictionary().Keys){
			if(CurrentValue <= 100){
				straightList.Add((byte)CurrentValue);
			}
		}

		foreach(int CurrentValue in curvedTileDictionary().Keys){
			if(CurrentValue <= 100){
				curvedList.Add((byte)CurrentValue);
			}
		}

		endTiles.Add(78);
		endTiles.Add(79);
		endTiles.Add(80);

		straightList.Sort();
		curvedList.Sort();

		maxValueStraight = (byte)(straightList.Count-1);
		maxValueCurved = (byte)(curvedList.Count-1);
	}

	public override void _Ready(){
		preLoad();
		if(manual_arena != ""){
			regenerateArena(manual_arena); 
		}
	}

	// public override void _Process(float delta){
	// }
}
