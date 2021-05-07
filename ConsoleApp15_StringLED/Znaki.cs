using System;

namespace ConsoleApp15_StringLED
{
    class Znaki
    {
        /// <summary>
        /// Funkcja
        /// </summary>
        /// <param name="ciag">Ciag znaków do wyświetlenia</param>
        /// <param name="i">Linia pozioma znaków każdej litery w ciągu</param>
        /// <param name="z">Znak wyświetlania napisu</param>
        /// <param name="s">Odstęp</param>
        /// <returns>Linia ciągu jednego literału</returns>
        public static char[] PrzypiszTablice(char ciag, int i, char z, char s)
        {
            #region ZERO
            char[][] zero = new char[7][];
            zero[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            zero[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            zero[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            zero[3] = $"{z}{s}{s}{s}{z}".ToCharArray();
            zero[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            zero[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            zero[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region JEDEN
            char[][] jeden = new char[7][];
            jeden[0] = $"{s}{s}{z}{s}{s}".ToCharArray();
            jeden[1] = $"{s}{z}{z}{s}{s}".ToCharArray();
            jeden[2] = $"{z}{s}{z}{s}{s}".ToCharArray();
            jeden[3] = $"{s}{s}{z}{s}{s}".ToCharArray();
            jeden[4] = $"{s}{s}{z}{s}{s}".ToCharArray();
            jeden[5] = $"{s}{s}{z}{s}{s}".ToCharArray();
            jeden[6] = $"{z}{z}{z}{z}{z}".ToCharArray();
            #endregion
            #region DWA
            char[][] dwa = new char[7][];
            dwa[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            dwa[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            dwa[2] = $"{s}{s}{s}{s}{z}".ToCharArray();
            dwa[3] = $"{s}{s}{s}{z}{s}".ToCharArray();
            dwa[4] = $"{s}{s}{z}{s}{s}".ToCharArray();
            dwa[5] = $"{s}{z}{s}{s}{s}".ToCharArray();
            dwa[6] = $"{z}{z}{z}{z}{z}".ToCharArray();
            #endregion
            #region TRZY
            char[][] trzy = new char[7][];
            trzy[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            trzy[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            trzy[2] = $"{s}{s}{s}{s}{z}".ToCharArray();
            trzy[3] = $"{s}{s}{z}{z}{s}".ToCharArray();
            trzy[4] = $"{s}{s}{s}{s}{z}".ToCharArray();
            trzy[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            trzy[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region CZTERY
            char[][] cztery = new char[7][];
            cztery[0] = $"{s}{s}{s}{z}{s}".ToCharArray();
            cztery[1] = $"{s}{s}{z}{z}{s}".ToCharArray();
            cztery[2] = $"{s}{z}{s}{z}{s}".ToCharArray();
            cztery[3] = $"{z}{s}{s}{z}{s}".ToCharArray();
            cztery[4] = $"{z}{z}{z}{z}{z}".ToCharArray();
            cztery[5] = $"{s}{s}{s}{z}{s}".ToCharArray();
            cztery[6] = $"{s}{s}{s}{z}{s}".ToCharArray();
            #endregion
            #region PIEC
            char[][] piec = new char[7][];
            piec[0] = $"{z}{z}{z}{z}{z}".ToCharArray();
            piec[1] = $"{z}{s}{s}{s}{s}".ToCharArray();
            piec[2] = $"{z}{s}{s}{s}{s}".ToCharArray();
            piec[3] = $"{s}{z}{z}{z}{s}".ToCharArray();
            piec[4] = $"{s}{s}{s}{s}{z}".ToCharArray();
            piec[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            piec[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region SZESC
            char[][] szesc = new char[7][];
            szesc[0] = $"{s}{s}{z}{z}{s}".ToCharArray();
            szesc[1] = $"{s}{z}{s}{s}{s}".ToCharArray();
            szesc[2] = $"{z}{s}{s}{s}{s}".ToCharArray();
            szesc[3] = $"{z}{z}{z}{z}{s}".ToCharArray();
            szesc[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            szesc[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            szesc[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region SIEDEM
            char[][] siedem = new char[7][];
            siedem[0] = $"{z}{z}{z}{z}{z}".ToCharArray();
            siedem[1] = $"{s}{s}{s}{s}{z}".ToCharArray();
            siedem[2] = $"{s}{s}{s}{z}{s}".ToCharArray();
            siedem[3] = $"{s}{s}{z}{s}{s}".ToCharArray();
            siedem[4] = $"{s}{z}{s}{s}{s}".ToCharArray();
            siedem[5] = $"{s}{z}{s}{s}{s}".ToCharArray();
            siedem[6] = $"{s}{z}{s}{s}{s}".ToCharArray();
            #endregion
            #region OSIEM
            char[][] osiem = new char[7][];
            osiem[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            osiem[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            osiem[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            osiem[3] = $"{s}{z}{z}{z}{s}".ToCharArray();
            osiem[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            osiem[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            osiem[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region DZIEWIEC
            char[][] dziewiec = new char[7][];
            dziewiec[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            dziewiec[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            dziewiec[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            dziewiec[3] = $"{s}{z}{z}{z}{z}".ToCharArray();
            dziewiec[4] = $"{s}{s}{s}{s}{z}".ToCharArray();
            dziewiec[5] = $"{s}{s}{s}{z}{s}".ToCharArray();
            dziewiec[6] = $"{s}{z}{z}{s}{s}".ToCharArray();
            #endregion
            
            #region A
            char[][] A = new char[7][];
            A[0] = $"{s}{s}{z}{s}{s}".ToCharArray();
            A[1] = $"{s}{z}{s}{z}{s}".ToCharArray();
            A[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            A[3] = $"{z}{s}{s}{s}{z}".ToCharArray();
            A[4] = $"{z}{z}{z}{z}{z}".ToCharArray();
            A[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            A[6] = $"{z}{s}{s}{s}{z}".ToCharArray();
            #endregion
            #region B
            char[][] B = new char[7][];
            B[0] = $"{z}{z}{z}{z}{s}".ToCharArray();
            B[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            B[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            B[3] = $"{z}{z}{z}{z}{s}".ToCharArray();
            B[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            B[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            B[6] = $"{z}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region C
            char[][] C = new char[7][];
            C[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            C[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            C[2] = $"{z}{s}{s}{s}{s}".ToCharArray();
            C[3] = $"{z}{s}{s}{s}{s}".ToCharArray();
            C[4] = $"{z}{s}{s}{s}{s}".ToCharArray();
            C[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            C[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region D
            char[][] D = new char[7][];
            D[0] = $"{z}{z}{z}{s}{s}".ToCharArray();
            D[1] = $"{z}{s}{s}{z}{s}".ToCharArray();
            D[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            D[3] = $"{z}{s}{s}{s}{z}".ToCharArray();
            D[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            D[5] = $"{z}{s}{s}{z}{s}".ToCharArray();
            D[6] = $"{z}{z}{z}{s}{s}".ToCharArray();
            #endregion
            #region E
            char[][] E = new char[7][];
            E[0] = $"{s}{z}{z}{z}{z}".ToCharArray();
            E[1] = $"{z}{s}{s}{s}{s}".ToCharArray();
            E[2] = $"{z}{s}{s}{s}{s}".ToCharArray();
            E[3] = $"{z}{z}{z}{z}{s}".ToCharArray();
            E[4] = $"{z}{s}{s}{s}{s}".ToCharArray();
            E[5] = $"{z}{s}{s}{s}{s}".ToCharArray();
            E[6] = $"{s}{z}{z}{z}{z}".ToCharArray();
            #endregion
            #region F
            char[][] F = new char[7][];
            F[0] = $"{z}{z}{z}{z}{z}".ToCharArray();
            F[1] = $"{z}{s}{s}{s}{s}".ToCharArray();
            F[2] = $"{z}{s}{s}{s}{s}".ToCharArray();
            F[3] = $"{z}{z}{z}{z}{s}".ToCharArray();
            F[4] = $"{z}{s}{s}{s}{s}".ToCharArray();
            F[5] = $"{z}{s}{s}{s}{s}".ToCharArray();
            F[6] = $"{z}{s}{s}{s}{s}".ToCharArray();
            #endregion
            #region G
            char[][] G = new char[7][];
            G[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            G[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            G[2] = $"{z}{s}{s}{s}{s}".ToCharArray();
            G[3] = $"{z}{s}{z}{z}{z}".ToCharArray();
            G[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            G[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            G[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region H
            char[][] H = new char[7][];
            H[0] = $"{z}{s}{s}{s}{z}".ToCharArray();
            H[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            H[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            H[3] = $"{z}{z}{z}{z}{z}".ToCharArray();
            H[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            H[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            H[6] = $"{z}{s}{s}{s}{z}".ToCharArray();
            #endregion
            #region I
            char[][] I = new char[7][];
            I[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            I[1] = $"{s}{s}{z}{s}{s}".ToCharArray();
            I[2] = $"{s}{s}{z}{s}{s}".ToCharArray();
            I[3] = $"{s}{s}{z}{s}{s}".ToCharArray();
            I[4] = $"{s}{s}{z}{s}{s}".ToCharArray();
            I[5] = $"{s}{s}{z}{s}{s}".ToCharArray();
            I[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region J
            char[][] J = new char[7][];
            J[0] = $"{z}{z}{z}{z}{z}".ToCharArray();
            J[1] = $"{s}{s}{s}{s}{z}".ToCharArray();
            J[2] = $"{s}{s}{s}{s}{z}".ToCharArray();
            J[3] = $"{s}{s}{s}{s}{z}".ToCharArray();
            J[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            J[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            J[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region K
            char[][] K = new char[7][];
            K[0] = $"{z}{s}{s}{s}{z}".ToCharArray();
            K[1] = $"{z}{s}{s}{z}{s}".ToCharArray();
            K[2] = $"{z}{s}{z}{s}{s}".ToCharArray();
            K[3] = $"{z}{z}{s}{s}{s}".ToCharArray();
            K[4] = $"{z}{s}{z}{s}{s}".ToCharArray();
            K[5] = $"{z}{s}{s}{z}{s}".ToCharArray();
            K[6] = $"{z}{s}{s}{s}{z}".ToCharArray();
            #endregion
            #region L
            char[][] L = new char[7][];
            L[0] = $"{z}{s}{s}{s}{s}".ToCharArray();
            L[1] = $"{z}{s}{s}{s}{s}".ToCharArray();
            L[2] = $"{z}{s}{s}{s}{s}".ToCharArray();
            L[3] = $"{z}{s}{s}{s}{s}".ToCharArray();
            L[4] = $"{z}{s}{s}{s}{s}".ToCharArray();
            L[5] = $"{z}{s}{s}{s}{s}".ToCharArray();
            L[6] = $"{z}{z}{z}{z}{z}".ToCharArray();
            #endregion
            #region M
            char[][] M = new char[7][];
            M[0] = $"{z}{s}{s}{s}{z}".ToCharArray();
            M[1] = $"{z}{z}{s}{z}{z}".ToCharArray();
            M[2] = $"{z}{s}{z}{s}{z}".ToCharArray();
            M[3] = $"{z}{s}{z}{s}{z}".ToCharArray();
            M[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            M[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            M[6] = $"{z}{s}{s}{s}{z}".ToCharArray();
            #endregion
            #region N
            char[][] N = new char[7][];
            N[0] = $"{z}{s}{s}{s}{z}".ToCharArray();
            N[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            N[2] = $"{z}{z}{s}{s}{z}".ToCharArray();
            N[3] = $"{z}{s}{z}{s}{z}".ToCharArray();
            N[4] = $"{z}{s}{s}{z}{z}".ToCharArray();
            N[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            N[6] = $"{z}{s}{s}{s}{z}".ToCharArray();
            #endregion
            #region O
            char[][] O = new char[7][];
            O[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            O[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            O[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            O[3] = $"{z}{s}{s}{s}{z}".ToCharArray();
            O[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            O[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            O[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region P
            char[][] P = new char[7][];
            P[0] = $"{z}{z}{z}{z}{s}".ToCharArray();
            P[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            P[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            P[3] = $"{z}{z}{z}{z}{s}".ToCharArray();
            P[4] = $"{z}{s}{s}{s}{s}".ToCharArray();
            P[5] = $"{z}{s}{s}{s}{s}".ToCharArray();
            P[6] = $"{z}{s}{s}{s}{s}".ToCharArray();
            #endregion
            #region Q
            char[][] Q = new char[7][];
            Q[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            Q[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            Q[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            Q[3] = $"{z}{s}{s}{s}{z}".ToCharArray();
            Q[4] = $"{z}{s}{z}{s}{z}".ToCharArray();
            Q[5] = $"{z}{s}{s}{z}{s}".ToCharArray();
            Q[6] = $"{s}{z}{z}{s}{z}".ToCharArray();
            #endregion
            #region R
            char[][] R = new char[7][];
            R[0] = $"{z}{z}{z}{z}{s}".ToCharArray();
            R[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            R[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            R[3] = $"{z}{z}{z}{z}{s}".ToCharArray();
            R[4] = $"{z}{s}{z}{s}{s}".ToCharArray();
            R[5] = $"{z}{s}{s}{z}{s}".ToCharArray();
            R[6] = $"{z}{s}{s}{s}{z}".ToCharArray();
            #endregion
            #region S
            char[][] S = new char[7][];
            S[0] = $"{s}{z}{z}{z}{s}".ToCharArray();
            S[1] = $"{z}{s}{z}{s}{z}".ToCharArray();
            S[2] = $"{z}{s}{s}{s}{s}".ToCharArray();
            S[3] = $"{s}{z}{z}{z}{s}".ToCharArray();
            S[4] = $"{s}{s}{s}{s}{z}".ToCharArray();
            S[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            S[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region T
            char[][] T = new char[7][];
            T[0] = $"{z}{z}{z}{z}{z}".ToCharArray();
            T[1] = $"{s}{s}{z}{s}{s}".ToCharArray();
            T[2] = $"{s}{s}{z}{s}{s}".ToCharArray();
            T[3] = $"{s}{s}{z}{s}{s}".ToCharArray();
            T[4] = $"{s}{s}{z}{s}{s}".ToCharArray();
            T[5] = $"{s}{s}{z}{s}{s}".ToCharArray();
            T[6] = $"{s}{s}{z}{s}{s}".ToCharArray();
            #endregion
            #region U
            char[][] U = new char[7][];
            U[0] = $"{z}{s}{s}{s}{z}".ToCharArray();
            U[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            U[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            U[3] = $"{z}{s}{s}{s}{z}".ToCharArray();
            U[4] = $"{z}{s}{s}{s}{z}".ToCharArray();
            U[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            U[6] = $"{s}{z}{z}{z}{s}".ToCharArray();
            #endregion
            #region V
            char[][] V = new char[7][];
            V[0] = $"{z}{s}{s}{s}{z}".ToCharArray();
            V[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            V[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            V[3] = $"{s}{z}{s}{z}{s}".ToCharArray();
            V[4] = $"{s}{z}{s}{z}{s}".ToCharArray();
            V[5] = $"{s}{s}{z}{s}{s}".ToCharArray();
            V[6] = $"{s}{s}{z}{s}{s}".ToCharArray();
            #endregion
            #region W
            char[][] W = new char[7][];
            W[0] = $"{z}{s}{s}{s}{z}".ToCharArray();
            W[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            W[2] = $"{z}{s}{s}{s}{z}".ToCharArray();
            W[3] = $"{z}{s}{z}{s}{z}".ToCharArray();
            W[4] = $"{z}{s}{z}{s}{z}".ToCharArray();
            W[5] = $"{z}{s}{z}{s}{z}".ToCharArray();
            W[6] = $"{s}{z}{s}{z}{s}".ToCharArray();
            #endregion
            #region X
            char[][] X = new char[7][];
            X[0] = $"{z}{s}{s}{s}{z}".ToCharArray();
            X[1] = $"{z}{s}{s}{s}{z}".ToCharArray();
            X[2] = $"{s}{z}{s}{z}{s}".ToCharArray();
            X[3] = $"{s}{s}{z}{s}{s}".ToCharArray();
            X[4] = $"{s}{z}{s}{z}{s}".ToCharArray();
            X[5] = $"{z}{s}{s}{s}{z}".ToCharArray();
            X[6] = $"{z}{s}{s}{s}{z}".ToCharArray();
            #endregion
            #region Y
            char[][] Y = new char[7][];
            Y[0] = $"{z}{s}{s}{s}{z}".ToCharArray();
            Y[1] = $"{s}{z}{s}{z}{s}".ToCharArray();
            Y[2] = $"{s}{z}{s}{z}{s}".ToCharArray();
            Y[3] = $"{s}{s}{z}{s}{s}".ToCharArray();
            Y[4] = $"{s}{s}{z}{s}{s}".ToCharArray();
            Y[5] = $"{s}{s}{z}{s}{s}".ToCharArray();
            Y[6] = $"{s}{s}{z}{s}{s}".ToCharArray();
            #endregion
            #region Z
            char[][] Z = new char[7][];
            Z[0] = $"{z}{z}{z}{z}{z}".ToCharArray();
            Z[1] = $"{s}{s}{s}{s}{z}".ToCharArray();
            Z[2] = $"{s}{s}{s}{z}{s}".ToCharArray();
            Z[3] = $"{s}{s}{z}{s}{s}".ToCharArray();
            Z[4] = $"{s}{z}{s}{s}{s}".ToCharArray();
            Z[5] = $"{z}{s}{s}{s}{s}".ToCharArray();
            Z[6] = $"{z}{z}{z}{z}{z}".ToCharArray();
            #endregion

            #region SPACJA
            char[][] spacja = new char[7][];
            spacja[0] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[1] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[2] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[3] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[4] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[5] = $"{s}{s}{s}{s}{s}".ToCharArray();
            spacja[6] = $"{s}{s}{s}{s}{s}".ToCharArray();
            #endregion
            #region KROPKA
            char[][] kropka = new char[7][];
            kropka[0] = $"{s}{s}{s}{s}{s}".ToCharArray();
            kropka[1] = $"{s}{s}{s}{s}{s}".ToCharArray();
            kropka[2] = $"{s}{s}{s}{s}{s}".ToCharArray();
            kropka[3] = $"{s}{s}{s}{s}{s}".ToCharArray();
            kropka[4] = $"{s}{s}{s}{s}{s}".ToCharArray();
            kropka[5] = $"{s}{s}{s}{s}{s}".ToCharArray();
            kropka[6] = $"{s}{s}{z}{s}{s}".ToCharArray();
            #endregion
            #region PRZECINEK
            char[][] przecinek = new char[7][];
            przecinek[0] = $"{s}{s}{s}{s}{s}".ToCharArray();
            przecinek[1] = $"{s}{s}{s}{s}{s}".ToCharArray();
            przecinek[2] = $"{s}{s}{s}{s}{s}".ToCharArray();
            przecinek[3] = $"{s}{s}{s}{s}{s}".ToCharArray();
            przecinek[4] = $"{s}{s}{s}{s}{s}".ToCharArray();
            przecinek[5] = $"{s}{s}{z}{s}{s}".ToCharArray();
            przecinek[6] = $"{s}{z}{s}{s}{s}".ToCharArray();
            #endregion
            #region MYSLNIK
            char[][] myslnik = new char[7][];
            myslnik[0] = $"{s}{s}{s}{s}{s}".ToCharArray();
            myslnik[1] = $"{s}{s}{s}{s}{s}".ToCharArray();
            myslnik[2] = $"{s}{s}{s}{s}{s}".ToCharArray();
            myslnik[3] = $"{s}{z}{z}{z}{z}".ToCharArray();
            myslnik[4] = $"{s}{s}{s}{s}{s}".ToCharArray();
            myslnik[5] = $"{s}{s}{s}{s}{s}".ToCharArray();
            myslnik[6] = $"{s}{s}{s}{s}{s}".ToCharArray();
            #endregion
            #region DWUKROPEK
            char[][] dwukropek = new char[7][];
            dwukropek[0] = $"{s}{s}{s}{s}{s}".ToCharArray();
            dwukropek[1] = $"{s}{s}{s}{s}{s}".ToCharArray();
            dwukropek[2] = $"{s}{s}{z}{s}{s}".ToCharArray();
            dwukropek[3] = $"{s}{s}{s}{s}{s}".ToCharArray();
            dwukropek[4] = $"{s}{s}{z}{s}{s}".ToCharArray();
            dwukropek[5] = $"{s}{s}{s}{s}{s}".ToCharArray();
            dwukropek[6] = $"{s}{s}{s}{s}{s}".ToCharArray();
            #endregion
            #region WYKRZYKNIK

            #endregion
            #region PYTAJNIK

            #endregion


            char[] znak = new char[5];

            switch (ciag)
            {
                case '0':
                    znak = zero[i];
                    break;
                case '1':
                    znak = jeden[i];
                    break;
                case '2':
                    znak = dwa[i];
                    break;
                case '3':
                    znak = trzy[i];
                    break;
                case '4':
                    znak = cztery[i];
                    break;
                case '5':
                    znak = piec[i];
                    break;
                case '6':
                    znak = szesc[i];
                    break;
                case '7':
                    znak = siedem[i];
                    break;
                case '8':
                    znak = osiem[i];
                    break;
                case '9':
                    znak = dziewiec[i];
                    break;

                case 'A':
                case 'a':
                    znak = A[i];
                    break;
                case 'B':
                case 'b':
                    znak = B[i];
                    break;
                case 'C':
                case 'c':
                    znak = C[i];
                    break;
                case 'D':
                case 'd':
                    znak = D[i];
                    break;
                case 'E':
                case 'e':
                    znak = E[i];
                    break;
                case 'F':
                case 'f':
                    znak = F[i];
                    break;
                case 'G':
                case 'g':
                    znak = G[i];
                    break;
                case 'H':
                case 'h':
                    znak = H[i];
                    break;
                case 'I':
                case 'i':
                    znak = I[i];
                    break;
                case 'J':
                case 'j':
                    znak = J[i];
                    break;
                case 'K':
                case 'k':
                    znak = K[i];
                    break;
                case 'L':
                case 'l':
                    znak = L[i];
                    break;
                case 'M':
                case 'm':
                    znak = M[i];
                    break;
                case 'N':
                case 'n':
                    znak = N[i];
                    break;
                case 'O':
                case 'o':
                    znak = O[i];
                    break;
                case 'P':
                case 'p':
                    znak = P[i];
                    break;
                case 'Q':
                case 'q':
                    znak = Q[i];
                    break;
                case 'R':
                case 'r':
                    znak = R[i];
                    break;
                case 'S':
                case 's':
                    znak = S[i];
                    break;
                case 'T':
                case 't':
                    znak = T[i];
                    break;
                case 'U':
                case 'u':
                    znak = U[i];
                    break;
                case 'V':
                case 'v':
                    znak = V[i];
                    break;
                case 'W':
                case 'w':
                    znak = W[i];
                    break;
                case 'X':
                case 'x':
                    znak = X[i];
                    break;
                case 'Y':
                case 'y':
                    znak = Y[i];
                    break;
                case 'Z':
                case 'z':
                    znak = Z[i];
                    break;

                case ' ':
                    znak = spacja[i];
                    break;
                case '.':
                    znak = kropka[i];
                    break;
                case ',':
                    znak = przecinek[i];
                    break;
                case '-':
                    znak = myslnik[i];
                    break;
                case ':':
                    znak = dwukropek[i];
                    break;
            }
            return znak;
        }
    }
}
