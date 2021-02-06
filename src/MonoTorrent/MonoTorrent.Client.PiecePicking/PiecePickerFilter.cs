﻿//
// PiecePickerFilter.cs
//
// Authors:
//   Alan McGovern alan.mcgovern@gmail.com
//
// Copyright (C) 2008 Alan McGovern
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//


using System.Collections.Generic;

namespace MonoTorrent.Client.PiecePicking
{
    public abstract class PiecePickerFilter : IPiecePicker
    {
        protected IPiecePicker Next { get; }

        protected PiecePickerFilter (IPiecePicker picker)
            => Next = picker;

        public int AbortRequests (IPeer peer)
            => Next.AbortRequests (peer);

        public IList<PieceRequest> CancelRequests (IPeer peer, int startIndex, int endIndex)
            => Next.CancelRequests (peer, startIndex, endIndex);

        public PieceRequest? ContinueAnyExistingRequest (IPeer peer, int startIndex, int endIndex, int maxDuplicateRequests)
            => Next.ContinueAnyExistingRequest (peer, startIndex, endIndex, maxDuplicateRequests);

        public PieceRequest? ContinueExistingRequest (IPeer peer, int startIndex, int endIndex)
            => Next.ContinueExistingRequest (peer, startIndex, endIndex);

        public int CurrentReceivedCount ()
            => Next.CurrentReceivedCount ();

        public int CurrentRequestCount ()
            => Next.CurrentRequestCount();

        public IList<ActivePieceRequest> ExportActiveRequests ()
            => Next.ExportActiveRequests ();

        public virtual void Initialise (ITorrentData torrentData)
            => Next.Initialise (torrentData);

        public virtual bool IsInteresting (IPeer peer, BitField bitfield)
            => Next.IsInteresting (peer, bitfield);

        public virtual IList<PieceRequest> PickPiece (IPeer peer, BitField available, IReadOnlyList<IPeer> otherPeers, int count, int startIndex, int endIndex)
            => Next.PickPiece (peer, available, otherPeers, count, startIndex, endIndex);

        public void RequestRejected (IPeer peer, PieceRequest request)
            => Next.RequestRejected (peer, request);

        public bool ValidatePiece (IPeer peer, PieceRequest request, out bool pieceComplete, out IList<IPeer> peersInvolved)
            => Next.ValidatePiece (peer, request, out pieceComplete, out peersInvolved);
    }
}
