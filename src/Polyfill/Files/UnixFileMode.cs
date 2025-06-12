
namespace Polyfills;

#if !NET7_0_OR_GREATER

#if PolyPublic
public
#endif
enum UnixFileMode
{
    None = 0,
    OtherExecute = 1,
    OtherWrite = 2,
    OtherRead = 4,
    GroupExecute = 8,
    GroupWrite = 16,
    GroupRead = 32,
    UserExecute = 64,
    UserWrite = 128,
    UserRead = 256,
    StickyBit = 512,
    SetGroup = 1024,
    SetUser = 2048
}

#endif