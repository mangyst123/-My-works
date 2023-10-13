type Title = String -- Название фигуры
type ChessGame = String -- Цвет фигуры
type Pair = (Char, Int) -- Координаты фигуры на доске
data PieceChess = PieceChess Title  ChessGame Pair deriving Show -- Общая информация о фигуре (Имя, цвет, позиция на поле)

white = "White"
black = "Black"
pieceChess = [ PieceChess "King"  white ('a', 1),-- Король
               PieceChess "King"  black ('b',5),
               PieceChess "Queen" white ('a',3), -- Ферзь
               PieceChess "Queen" black ('d',6),
               PieceChess "Rook" white ('c',2), -- Ладья
               PieceChess "Rook" black ('b',7),
               PieceChess "Elephant" white ('c',12), -- Слон
               PieceChess "Elephant" black ('f',6),
               PieceChess "Horse" white ('f',1), -- Конь
               PieceChess "Horse" black ('g',8),
               PieceChess "Pawn" white ('h',5), -- Пешка
               PieceChess "Pawn" black ('h',7)]
getmun :: PieceChess -> String -> Int -- Возвращает 1 если цвет фигурки совпадает с заданным
getmun (PieceChess a b c) z | b == z = 1
                            | otherwise = 0

getpos :: PieceChess -> [Pair] -- Возвращает координаты заданной фигурки
getpos (PieceChess a b c) = [c]

isoccupiedPosition :: PieceChess -> Pair -> Bool -- Возвращает True если координата фигурки совпадает с заданой
isoccupiedPosition (PieceChess a b c) z | z == c = True
                                         | otherwise = False

numberChessmen :: [PieceChess] -> String -> Int -- Возвращает количество фигур заданного цвета
numberChessmen [] z = 0
numberChessmen (x:xs) z = getmun x z + numberChessmen xs z

positionsByColor :: [PieceChess] -> String -> [Pair] -- Возвращает список координат фигурок у которых цвет совпал с заданным
positionsByColor [] z = []
positionsByColor (x:xs) z | getmun x z == 1 = getpos x ++ positionsByColor xs z
                          | otherwise = positionsByColor xs z

isEmpty :: [PieceChess] -> Pair -> Bool -- Возвращает True если заданная клетка не занята фигуркой
isEmpty [] _ = True
isEmpty (x:xs) z |isoccupiedPosition x z == True = False
                 |isoccupiedPosition x z == False = isEmpty xs z

main :: IO ()
main = do -- Функция выводит результаты работы следующих 3х функций\textbf{}
    print $ numberChessmen pieceChess white
    print $ positionsByColor pieceChess white
    print $ isEmpty pieceChess ('a', 1)
