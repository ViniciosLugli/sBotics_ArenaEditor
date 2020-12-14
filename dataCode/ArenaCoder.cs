using Godot;
using System.Collections.Generic;
using System;

public class Tile{
	public short x { get; set; }
	public short y { get; set; }
	public short degrees { get; set; }
	public string type { get; set; }
	public short id{ get; set; }
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
		string[] final_code = (native_code.Replace(" ", "").Replace("\n", "").Replace("\r", "").Replace("\b", "").Replace("\t", "")).Split(new char[] { ',' });
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
		short pos_x = byte.Parse(reverse(code.Substring(0, 2)));
		short pos_y = byte.Parse(reverse(code.Substring(2, 2)));
		short direction = short.Parse(code.Substring(6, 3));
		string compl0 = code.Substring(4, 1);
		short compl1 = (short)GetIndex(code.Substring(5, 1));
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
		return new Dictionary<int, string>
		{
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
	public Dictionary<int, string> curvedTileDictionary()
	{
		return new Dictionary<int, string>
		{
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
	public CleitonCoders coder = new CleitonCoders();

	public Vector2 getTilePos(byte tile_x, byte tile_y){
		return new Vector2( (short)(448+ (tile_x*256)), (short)(632 - (tile_y*256)));
	}

	public Texture loadTile(string type, short id){
		if(type.ToLower() == "r"){
			return (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Ladrilhos/Retas/{id}.png");
		}else if(type.ToLower() == "c"){
			return (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Ladrilhos/Curvas/{id}.png");
		}return (Texture)ResourceLoader.Load($"res://dataFile/2D assets/Outros/Fundo_branco.png");
	}

	public void setArena(string arena_code){
		string[] final_code = coder.filter(arena_code);
		Tile TempTile;
		foreach (string code in final_code){
			TempTile = coder.decode(code);
			Sprite CurrentChild = (Sprite)TileBase_scene.Instance();
			CurrentChild.GetNode<Sprite>("TileBase").Texture = loadTile(TempTile.type, TempTile.id);
			//alias
			/*if (TempTile.id == 73){
				
			}*/
			//
			CurrentChild.Position = getTilePos((byte)TempTile.x, (byte)TempTile.y);
			CurrentChild.RotationDegrees = TempTile.degrees;
			//GD.Print($"Added child in: { getTilePos((byte)TempTile.x, (byte)TempTile.y)}");
			AddChild(CurrentChild);
		}
	}

	public override void _Ready(){
		if(manual_arena != ""){
			setArena(manual_arena);
		}
	}

	public override void _Process(float delta){

	}
}
