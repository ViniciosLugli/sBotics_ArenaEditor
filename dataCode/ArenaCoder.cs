using Godot;
using System.Collections.Generic;
using System;
using System.Linq;

public class Tile{
	public short x{get;set;}
	public short y{get;set;}
	public short degrees{get;set;}
	public string type{get;set;}
	public short id{get;set;}
	public Tile(short x, short y, short degrees, string type, short id){
		this.x = x;
		this.y = y;
		this.degrees = degrees;
		this.type = type;
		this.id = id;
	}
}

public class CleitonCoders{
	public static string reverse(string s){
		char[] arr = s.ToCharArray();
		Array.Reverse(arr);
		return new string(arr);
	}

	public string[] filter(string native_code){
		string[] final_code = (native_code.Replace("\n", "").Replace("\r", "").Replace("\b", "").Replace("\t", "")).Split(new char[] { ',' });
		GD.Print($"Codes array: {string.Join(", ", final_code)}");
		return final_code;
	}

	public int GetIndex(string c) {
		Dictionary<string, int> BaseDecoder = this.tileDictionary();
		int result = 777;
		try{
			result = (byte)BaseDecoder[c];
		}catch{
			result = 0;
		}
		return result;
	}

	public string getStraight(int index){
		Dictionary<int, string> BaseDecoder = this.straightTileDictionary();
		string result = "Penis";
		try{
			result = BaseDecoder[index];
		}catch{
			result = "Não encontrado";
		}
		return result;
	}

	public string getCurved(int index){
		Dictionary<int, string> BaseDecoder = this.curvedTileDictionary();
		string result = "sim!";
		try{
			result = BaseDecoder[index];
		}catch{
			result = "Não encontrado";
		}
		return result;
	}

	public Tile decode(string code){
		short pos_x = 0;
		short pos_y = 0;
		short direction = 0;
		string compl0 = "r";
		short compl1 = 0;
		try
		{
			pos_x = byte.Parse(reverse(code.Substring(0, 2)));
			pos_y = byte.Parse(reverse(code.Substring(2, 2)));
			direction = short.Parse(code.Substring(6, 3));
			compl0 = code.Substring(4, 1);
			compl1 = (short)GetIndex(code.Substring(5, 1));
		}catch{
			GD.Print($"The code: {code} is not a tile code! Returning emply tile");
			return new Tile(0, 0, 0, "r", 71);
		}

		direction = (direction != 0 && direction != 90 && direction != 180 && direction != 270) ? (short)0 : direction;
		GD.Print($"For code: '{code}' -> position: <{pos_x}, {pos_y}> | direction: {direction} | complement: <{compl0}, {compl1}>");
		return new Tile(pos_x, pos_y, direction, compl0, compl1);
	}

	public void encode(){
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
}

public class ArenaCoder : Node2D {

	[Export] public string manual_arena = "";

	private PackedScene TileBase_scene = (PackedScene)ResourceLoader.Load("res://dataScenes/TileBase.tscn");
	private PackedScene UnderLine_scene = (PackedScene)ResourceLoader.Load("res://dataScenes/UnderLine.tscn");
	private Texture BaseWhite_texture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Complementares/Fundo_branco.png");
	public CleitonCoders coder = new CleitonCoders();

	//Geral
	Tile RescueDat = new Tile(0, 0, 0, "null", 0);
	Tile EndingDat = new Tile(0, 0, 0, "null", 0);
	Vector2 OffsetRescue =  new Vector2(10, 256);
	string[] Zindex2 = new string[]{"r73"};
	string[] UnderLineTiles = new string[]{"r26", "r27", "r28", "r29", "r30", "r31", "r38", "r40", "r42", "r44", "r46", "r48", "r53", "r59", "r62", "r65", "r70"};
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
	public void updateInfoMenu(){
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

	public Vector2 getTilePos(byte tile_x, byte tile_y){
		tile_x = (byte)((tile_x > 9) ? ((tile_x < 0) ? 0 : tile_x) : tile_x);
		tile_y = (byte)((tile_y > 9) ? ((tile_y < 0) ? 0 : tile_y) : tile_y);
		return new Vector2( (short)(448 + (tile_x * 256)), (short)(632 - (tile_y * 256)));
	}

	public void reserve(string tileconfig){
		additional += $",{tileconfig}";
	}

	private void resetArena(){//reset all default
		RescueDat = new Tile(0, 0, 0, "null", 0);
		EndingDat = new Tile(0, 0, 0, "null", 0);
		BoolEndCd = false;
		BoolNoPos = false;
		BoolPrgso = false;
		BoolShowM = false;
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
		SaveMrcds = 0;
		TempoMxmo = 3;
		VitmaPnts = false;
		//string[] VelaAcesa;
		//string[] VelaApgda;
		//string[] VitimOrta;
		//string[] VitimViva;
		VtmsMrtas = 2;
		VtmsVivas = 1;
		//string[] prfsrCubo;
		RescueTyp = 1;
	}

	public byte getZindex(string type, short id){
		//string[] Zindex3 = new string[]{};
		if(Zindex2.Contains($"{type}{id}")){
			return 2;
		}else{
			return 1;
		}
	}

	public bool filterFlags(Tile ctile){
		if((ctile.type == "r") && (ctile.id == 73) && (RescueDat.type == "null") && (EndingDat.type == "null")){
			RescueDat = ctile;
			return true;
		}
		return false;
	}

	public void loadFlags(){
		if(RescueDat.type != "null"){
			addTile(RescueDat, (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Ladrilhos/Retas/{RescueDat.id}_{RescueTyp}.png"), false, OffsetRescue);
		}
	}

	public Texture loadTextureTile(string type, short id){
		try{
			if(type.ToLower() == "r"){
				return (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Ladrilhos/Retas/{id}.png");
			}else if(type.ToLower() == "c"){
				return (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Ladrilhos/Curvas/{id}.png");
			}
		}catch{
			GD.Print($"Error on import tile with type {type} and id: {id}");
			return BaseWhite_texture;
		}
		return BaseWhite_texture;
	}
		
	public void addTile(Tile CurrentTile, Texture CurrentTexture, bool SetTileBase, Vector2 OffsetTileBase){
		if(CurrentTile.type == "null"){return;}
		Sprite CurrentChild = (Sprite)TileBase_scene.Instance();
		CurrentChild.GetNode<Sprite>("TileBase").Texture = CurrentTexture;
		CurrentChild.GetNode<Sprite>("TileBase").Offset = OffsetTileBase;
		if(SetTileBase){
			CurrentChild.Texture = BaseWhite_texture;
		}
		CurrentChild.ZIndex = getZindex(CurrentTile.type, CurrentTile.id);
		CurrentChild.Position = getTilePos((byte)CurrentTile.x, (byte)CurrentTile.y);
		CurrentChild.RotationDegrees = CurrentTile.degrees;
		//CurrentChild.Name = $"{CurrentTile.x}{CurrentTile.x}";
		//Case underline tile:
		if(UnderLineTiles.Contains($"{CurrentTile.type}{CurrentTile.id}")){
			CurrentChild.GetNode<Sprite>("Filter").Texture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Complementares/Filtro_Azul_Linha.png");
			GD.Print($"Underline: {CurrentTile.type}{CurrentTile.id}");
			Area2D CurrentUnderLine = (Area2D)UnderLine_scene.Instance();
			CurrentUnderLine.GetNode<Sprite>("UnderLineSprite").Texture = (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Ladrilhos/Retas/{CurrentTile.id}_.png");
			CurrentChild.AddChild(CurrentUnderLine);
		}
		AddChild(CurrentChild);
	}

	public void regenerateArena(string arena_code){
		resetArena();

		string[] final_code = coder.filter(arena_code);
		Tile CurrentTile;
		foreach (string code in final_code){
			if(code.Length > 9){
				if(code.Substring(0, 10) != "Descricao:"){
					code.Replace(" ", "");
				}else{
					Descricao = code.Substring(10);
				}
			}else{code.Replace(" ", "");}
			if(code.Length == 9){//Normal tile
				CurrentTile = coder.decode(code);
				if(filterFlags(CurrentTile)){continue;}
				addTile(CurrentTile, loadTextureTile(CurrentTile.type, CurrentTile.id), true, new Vector2(0, 0));

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
						  string[] HorarioArray = code.Substring(10).Split(':');
							if (code.Substring(10) == HorarioArray[0]){
								HoraDoDia = new string[]{"12", "00"};
								break;
							}
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
							reserve(code);
							break;
				  	}
				}catch (Exception ex){
					GD.Print($"Error on load switch code: {code}, with exception: {ex.Message}");
					additional += $",{code}";
				}
			}
		}
		loadFlags();
		//updateInfoMenu();
	}

	public override void _Ready(){
		if(manual_arena != ""){
			regenerateArena(manual_arena);
		}
	}

	public override void _Process(float delta){

	}
}
