using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ToggleFullscreen
{
	/// <summary>
	/// ゲームメインクラス
	/// </summary>
	public class Game1 : Game
	{
    /// <summary>
    /// グラフィックデバイス管理クラス
    /// </summary>
    private readonly GraphicsDeviceManager _graphics = null;

    /// <summary>
    /// スプライトのバッチ化クラス
    /// </summary>
    private SpriteBatch _spriteBatch = null;

    /// <summary>
    /// スペースキー押下フラグ
    /// </summary>
    private bool _pushed = false;


    /// <summary>
    /// GameMain コンストラクタ
    /// </summary>
    public Game1()
    {
      // グラフィックデバイス管理クラスの作成
      _graphics = new GraphicsDeviceManager(this);

      // ゲームコンテンツのルートディレクトリを設定
      Content.RootDirectory = "Content";

      // マウスカーソルを表示
      IsMouseVisible = true;
    }

    /// <summary>
    /// ゲームが始まる前の初期化処理を行うメソッド
    /// グラフィック以外のデータの読み込み、コンポーネントの初期化を行う
    /// </summary>
    protected override void Initialize()
    {
      // TODO: ここに初期化ロジックを書いてください

      // コンポーネントの初期化などを行います
      base.Initialize();
    }

    /// <summary>
    /// ゲームが始まるときに一回だけ呼ばれ
    /// すべてのゲームコンテンツを読み込みます
    /// </summary>
    protected override void LoadContent()
    {
      // テクスチャーを描画するためのスプライトバッチクラスを作成します
      _spriteBatch = new SpriteBatch(GraphicsDevice);

      // TODO: Content を使用してゲームコンテンツを読み込む
      //       ロジックを書いてください
    }

    /// <summary>
    /// ゲームが終了するときに一回だけ呼ばれ
    /// すべてのゲームコンテンツをアンロードします
    /// </summary>
    protected override void UnloadContent()
    {
      // TODO: ContentManager で管理されていないコンテンツを
      //       ここでアンロードしてください
    }

    /// <summary>
    /// 描画以外のデータ更新等の処理を行うメソッド
    /// 主に入力処理、衝突判定などの物理計算、オーディオの再生など
    /// </summary>
    /// <param name="gameTime">このメソッドが呼ばれたときのゲーム時間</param>
    protected override void Update(GameTime gameTime)
    {
      // キーボードの状態を取得
      MouseState mouseState = Mouse.GetState();

      // ゲームパッドの状態を取得
      GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);

      // Xbox 360 コントローラ、Windows Phone の の BACK ボタン、
      // またはマウスの右ボタンを押したときにゲームを終了させます
      if (gamepadState.Buttons.Back == ButtonState.Pressed ||
          mouseState.RightButton == ButtonState.Pressed ||
          Keyboard.GetState().IsKeyDown(Keys.Escape))
      {
        Exit();
      }

      // マウスの左ボタン、または Xbox 360 コントローラの A ボタンを押したとき
      // ウインドウモードとフルスクリーンモードを切り替える
      if (!_pushed &&
          (mouseState.LeftButton == ButtonState.Pressed ||
           gamepadState.Buttons.A == ButtonState.Pressed))
      {
        // ウインドウモードとフルスクリーンモードを切り替える
        _graphics.ToggleFullScreen();
      }

      // 押下状態記憶
      _pushed = mouseState.LeftButton == ButtonState.Pressed |
                    gamepadState.Buttons.A == ButtonState.Pressed;

      // 登録された GameComponent を更新する
      base.Update(gameTime);
    }

    /// <summary>
    /// 描画処理を行うメソッド
    /// </summary>
    /// <param name="gameTime">このメソッドが呼ばれたときのゲーム時間</param>
    protected override void Draw(GameTime gameTime)
    {
      // 画面を指定した色でクリアします
      GraphicsDevice.Clear(Color.CornflowerBlue);

      // TODO: ここに描画処理を記述します

      // 登録された DrawableGameComponent を描画する
      base.Draw(gameTime);
    }
  }
}
